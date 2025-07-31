using BuildingBlocks.Exceptions;
using MediatR;
using Moq;
using PainterPriceOfferServcie.Application.Features.BaseSettings.Commands.UpdateBaseSetting;
using PainterPriceOfferServcie.Application.Interfaces.Persistence;
using PainterPriceOfferServcie.Domain.Entity;

namespace PainterPriceOfferService.UnitTest.Application.BaseSetting.Commands
{
    public class UpdateBaseSettingCommandHandlerTests
    {
        private readonly Mock<IBaseSettingRepository> _mockRepository;
        private readonly UpdateBaseSettingCommandHandler _handler;

        public UpdateBaseSettingCommandHandlerTests()
        {
            _mockRepository = new Mock<IBaseSettingRepository>();
            _handler = new UpdateBaseSettingCommandHandler(_mockRepository.Object);
        }

        private UpdateBaseSettingCommand GetValidCommand() =>
            new(
                Id: "base-123",
                UserId: "user-xyz",
                DocumentTitle: "Frissített ajánlat",
                DefaultAfaSelected: true,
                AfaText: "Áfás verzió",
                NotAfaText: "Nem áfás verzió",
                AfaKey: 27
            );

        [Fact]
        public async Task Handle_ShouldUpdate_WhenBaseSettingExists_AndIdMatches()
        {
            // Arrange
            var command = GetValidCommand();

            var existing = new BaseSettings
            {
                Id = command.Id,
                UserId = command.UserId,
                DocumentTitle = "Régi ajánlat",
                DefaultAfaSelected = false,
                AfaText = "Régi Áfa",
                NotAfaText = "Régi nem Áfa",
                AfaKey = 5
            };

            BaseSettings? updated = null;

            _mockRepository.Setup(r =>
                r.GetByUserIdAsync(command.UserId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(existing);

            _mockRepository.Setup(r =>
                r.UpdateAsync(It.IsAny<BaseSettings>(), It.IsAny<CancellationToken>()))
                .Callback<BaseSettings, CancellationToken>((b, _) => updated = b)
                .Returns(Task.CompletedTask);

            // Act
            var result = await ((IRequestHandler<UpdateBaseSettingCommand, Unit>)_handler).Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(updated);
            Assert.Equal(command.Id, updated!.Id);
            Assert.Equal(command.UserId, updated.UserId);
            Assert.Equal(command.DocumentTitle, updated.DocumentTitle);
            Assert.Equal(command.DefaultAfaSelected, updated.DefaultAfaSelected);
            Assert.Equal(command.AfaText, updated.AfaText);
            Assert.Equal(command.NotAfaText, updated.NotAfaText);
            Assert.Equal(command.AfaKey, updated.AfaKey);

            _mockRepository.Verify(r =>
                r.UpdateAsync(It.IsAny<BaseSettings>(), It.IsAny<CancellationToken>()), Times.Once);

            Assert.Equal(Unit.Value, result);
        }

        [Fact]
        public async Task Handle_ShouldThrowNotFoundException_WhenBaseSettingDoesNotExist()
        {
            // Arrange
            var command = GetValidCommand();

            _mockRepository.Setup(r =>
                r.GetByUserIdAsync(command.UserId, It.IsAny<CancellationToken>()))
                .ReturnsAsync((BaseSettings?)null);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() =>((IRequestHandler<UpdateBaseSettingCommand, Unit>)_handler).Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_ShouldThrowBadRequestException_WhenIdDoesNotMatch()
        {
            // Arrange
            var command = GetValidCommand();

            var existing = new BaseSettings
            {
                Id = "mismatched-id", // fontos: nem egyezik
                UserId = command.UserId,
                DocumentTitle = "Bármi",
                DefaultAfaSelected = true,
                AfaText = "Áfa",
                NotAfaText = "Nem Áfa",
                AfaKey = 25
            };

            _mockRepository.Setup(r =>
                r.GetByUserIdAsync(command.UserId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(existing);

            // Act & Assert
            await Assert.ThrowsAsync<BadRequestException>(() => ((IRequestHandler<UpdateBaseSettingCommand, Unit>)_handler).Handle(command, CancellationToken.None));
        }
    }
}
