using BuildingBlocks.Exceptions;
using MediatR;
using PainterPriceOfferServcie.Application.Interfaces.Persistence;

namespace PainterPriceOfferServcie.Application.Features.WorkUnits.Commands.DeleteWorkUnit
{
    public class DeleteWorkUnitCommandHandler : IRequestHandler<DeleteWorkUnitCommand, Unit>
    {
        private readonly IWorkUnitRepository _workUnitRepository;
        public DeleteWorkUnitCommandHandler(IWorkUnitRepository workUnitRepository)
        {
            _workUnitRepository = workUnitRepository;
        }

        public async Task<Unit> Handle(DeleteWorkUnitCommand request, CancellationToken cancellationToken)
        {
            // Check if the work unit exists
            var workUnit = await _workUnitRepository.GetByIdAsync(request.Id, cancellationToken);
            if (workUnit == null)
            {
                throw new NotFoundException($"Work unit with ID '{request.Id}' not found.");
            }

            // Check if the work unit is enabled to edit
            if (!workUnit.IsEnabledToEdit)
            {
                throw new BadRequestException("This work unit is not enabled to edit.");
            }

            // Mark the work unit as deleted
            workUnit.IsDeleted = true;
            // Update the work unit in the repository
            await _workUnitRepository.UpdateAsync(workUnit, cancellationToken);
            return Unit.Value;
        }
    }
}
