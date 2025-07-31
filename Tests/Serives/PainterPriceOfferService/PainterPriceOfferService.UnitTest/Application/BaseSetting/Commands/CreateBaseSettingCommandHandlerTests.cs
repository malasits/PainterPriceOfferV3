using BuildingBlocks.Exceptions;
using MediatR;
using Moq;
using PainterPriceOfferServcie.Application.Features.BaseSettings.Commands.CreateBaseSetting;
using PainterPriceOfferServcie.Application.Interfaces.Persistence;

namespace PainterPriceOfferService.UnitTest.Application.BaseSetting.Commands
{
    namespace PainterPriceOfferService.UnitTest.Application.BaseSettings.Commands
    {
        public class CreateBaseSettingCommandHandlerTests
        {
            private readonly Mock<IBaseSettingRepository> _mockRepository;
            private readonly CreateBaseSettingCommandHandler _handler;

            public CreateBaseSettingCommandHandlerTests()
            {
                _mockRepository = new Mock<IBaseSettingRepository>();
                _handler = new CreateBaseSettingCommandHandler(_mockRepository.Object);
            }

            [Fact]
            public async Task Handle_ShouldCreateBaseSetting_WhenNoneExists()
            {
                // Arrange
                var command = new CreateBaseSettingCommand(
                    UserId: "user123",
                    DocumentTitle: "Árajánlat",
                    DefaultAfaSelected: true,
                    AfaText: "Áfás számlázás",
                    NotAfaText: "Áfa nélküli számlázás",
                    AfaKey: 27
                );

                _mockRepository.Setup(r => r.GetByUserIdAsync(command.UserId, It.IsAny<CancellationToken>()))
                               .ReturnsAsync((PainterPriceOfferServcie.Domain.Entity.BaseSettings?)null);

                _mockRepository.Setup(r => r.AddAsync(It.IsAny<PainterPriceOfferServcie.Domain.Entity.BaseSettings>(), It.IsAny<CancellationToken>()))
                               .Returns(Task.CompletedTask);

                // Act
                var result = await _handler.Handle(command, CancellationToken.None);

                // Assert
                _mockRepository.Verify(r => r.AddAsync(It.Is<PainterPriceOfferServcie.Domain.Entity.BaseSettings>(
                    b => b.UserId == command.UserId &&
                         b.DocumentTitle == command.DocumentTitle &&
                         b.DefaultAfaSelected == command.DefaultAfaSelected &&
                         b.AfaText == command.AfaText &&
                         b.NotAfaText == command.NotAfaText &&
                         b.AfaKey == command.AfaKey
                ), It.IsAny<CancellationToken>()), Times.Once);

                Assert.Equal(Unit.Value, result);
            }

            [Fact]
            public async Task Handle_ShouldThrowBadRequestException_WhenBaseSettingAlreadyExists()
            {
                // Arrange
                var command = new CreateBaseSettingCommand(
                    UserId: "user123",
                    DocumentTitle: "Dummy",
                    DefaultAfaSelected: false,
                    AfaText: "",
                    NotAfaText: "",
                    AfaKey: 27
                );

                var existing = new PainterPriceOfferServcie.Domain.Entity.BaseSettings()
                {
                    AfaKey = 27,
                    UserId = command.UserId,
                    DocumentTitle = command.DocumentTitle,
                    DefaultAfaSelected = command.DefaultAfaSelected,
                    AfaText = command.AfaText,
                    NotAfaText = command.NotAfaText
                };

                _mockRepository.Setup(r => r.GetByUserIdAsync(command.UserId, It.IsAny<CancellationToken>()))
                               .ReturnsAsync(existing);

                // Act & Assert
                await Assert.ThrowsAsync<BadRequestException>(() =>
                    _handler.Handle(command, CancellationToken.None));
            }
        }
    }
}
