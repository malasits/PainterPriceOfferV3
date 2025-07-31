using FluentValidation;
using MediatR;
using Moq;
using PainterPriceOfferServcie.Application.Features.WorkUnits.Commands.CreateWorkUnit;
using PainterPriceOfferServcie.Application.Interfaces.Persistence;

namespace PainterPriceOfferService.UnitTest.Application.WorkUnit.Commands
{
    public class CreateWorkUnitCommandHandlerTests
    {
        private readonly Mock<IWorkUnitRepository> _mockRepository;
        private readonly CreateWorkUnitCommandHandler _handler;

        public CreateWorkUnitCommandHandlerTests()
        {
            _mockRepository = new Mock<IWorkUnitRepository>();
            _handler = new CreateWorkUnitCommandHandler(_mockRepository.Object);
        }

        [Fact]
        public async Task Handle_ShouldCreateWorkUnit_WhenNameIsUnique()
        {
            // Arrange
            var command = new CreateWorkUnitCommand("TestUnit", "user1");
            _mockRepository.Setup(r => r.IsWorkUnitExistsByName(command.Name, null, It.IsAny<CancellationToken>()))
                           .ReturnsAsync(false);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            _mockRepository.Verify(r =>
                r.AddAsync(
                    It.Is<PainterPriceOfferServcie.Domain.Entity.WorkUnit>(w => w.Name == "TestUnit"),
                    It.IsAny<CancellationToken>()),
                Times.Once);
            Assert.Equal(Unit.Value, result);
        }

        [Fact]
        public async Task Handle_ShouldThrowValidationException_WhenNameAlreadyExists()
        {
            // Arrange
            var command = new CreateWorkUnitCommand("ExistingUnit", "user1");
            _mockRepository.Setup(r => r.IsWorkUnitExistsByName(command.Name, null, It.IsAny<CancellationToken>()))
                           .ReturnsAsync(true);

            // Act & Assert
            await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}
