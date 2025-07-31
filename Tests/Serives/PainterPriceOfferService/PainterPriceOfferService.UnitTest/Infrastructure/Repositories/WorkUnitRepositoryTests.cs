using Moq;
using PainterPriceOfferServcie.Application.Features.WorkUnits.Commands.CreateWorkUnit;
using PainterPriceOfferServcie.Application.Interfaces.Persistence;
using PainterPriceOfferServcie.Domain.Entity;

namespace PainterPriceOfferService.UnitTest.Infrastructure.Repositories
{
    public class WorkUnitRepositoryTests
    {
        private readonly Mock<IWorkUnitRepository> _mockRepository;
        private readonly CreateWorkUnitCommandHandler _handler;

        public WorkUnitRepositoryTests()
        {
            _mockRepository = new Mock<IWorkUnitRepository>();
            _handler = new CreateWorkUnitCommandHandler(_mockRepository.Object);
        }

        [Fact]
        public async Task Handle_ShouldPropagateException_WhenRepositoryThrows()
        {
            var command = new CreateWorkUnitCommand("TestUnit", "user1");

            _mockRepository.Setup(r =>
                r.IsWorkUnitExistsByName(command.Name, null, It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            _mockRepository.Setup(r =>
                r.AddAsync(It.IsAny<WorkUnit>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Database error"));

            var exception = await Assert.ThrowsAsync<Exception>(() =>
                _handler.Handle(command, CancellationToken.None));

            Assert.Equal("Database error", exception.Message);
        }
    }
}
