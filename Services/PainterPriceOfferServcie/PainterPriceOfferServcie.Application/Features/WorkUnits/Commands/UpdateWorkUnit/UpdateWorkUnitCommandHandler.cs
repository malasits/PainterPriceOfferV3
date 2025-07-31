using BuildingBlocks.Exceptions;
using FluentValidation;
using MediatR;
using PainterPriceOfferServcie.Application.Interfaces.Persistence;

namespace PainterPriceOfferServcie.Application.Features.WorkUnits.Commands.UpdateWorkUnit
{
    public class UpdateWorkUnitCommandHandler : IRequestHandler<UpdateWorkUnitCommand, Unit>
    {
        private IWorkUnitRepository _workUnitRepository;
        public UpdateWorkUnitCommandHandler(IWorkUnitRepository workUnitRepository)
        {
            _workUnitRepository = workUnitRepository;
        }

        public async Task<Unit> Handle(UpdateWorkUnitCommand request, CancellationToken cancellationToken)
        {
            // Validate unique name before updating
            if (await _workUnitRepository.IsWorkUnitExistsByName(request.Name, request.Id, cancellationToken))
            {
                throw new ValidationException($"Work unit with name '{request.Name}' already exists.");
            }

            // Update the work unit in the database
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

            // Update the properties
            workUnit.Name = request.Name;
            workUnit.IsActive = request.IsActive;
            workUnit.IsDeleted = request.IsDeleted;

            await _workUnitRepository.UpdateAsync(workUnit, cancellationToken);
            return Unit.Value;
        }
    }
}
