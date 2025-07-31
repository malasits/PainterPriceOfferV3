using BuildingBlocks.Exceptions;
using MediatR;
using PainterPriceOfferServcie.Application.Interfaces.Persistence;

namespace PainterPriceOfferServcie.Application.Features.MaterialUnits.Commands.DeleteMaterialUnit
{
    public class DeleteMaterialUnitCommandHandler : IRequestHandler<DeleteMaterialUnitCommand, Unit>
    {
        private IMaterialUnitRepository _materialUnitRepository;
        public DeleteMaterialUnitCommandHandler(IMaterialUnitRepository materialUnitRepository)
        {
            _materialUnitRepository = materialUnitRepository;
        }

        public async Task<Unit> Handle(DeleteMaterialUnitCommand request, CancellationToken cancellationToken)
        {
            // Check if the material unit exists
            var materialUnit = await _materialUnitRepository.GetByIdAsync(request.Id, cancellationToken);
            if (materialUnit == null)
            {
                throw new NotFoundException($"Material unit with ID '{request.Id}' not found.");
            }

            // Check if the material unit is enabled to edit
            if (!materialUnit.IsEnabledToEdit)
            {
                throw new BadRequestException("This material unit is not enabled to edit.");
            }

            // Mark the material unit as deleted
            materialUnit.IsDeleted = true;
            // Update the material unit in the repository
            await _materialUnitRepository.UpdateAsync(materialUnit, cancellationToken);
            return Unit.Value;
        }
    }
}
