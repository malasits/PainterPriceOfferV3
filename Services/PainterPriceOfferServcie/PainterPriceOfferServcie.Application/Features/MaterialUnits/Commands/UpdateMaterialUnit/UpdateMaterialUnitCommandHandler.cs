using BuildingBlocks.Exceptions;
using FluentValidation;
using MediatR;
using PainterPriceOfferServcie.Application.Interfaces.Persistence;

namespace PainterPriceOfferServcie.Application.Features.MaterialUnits.Commands.UpdateMaterialUnit
{
    public class UpdateMaterialUnitCommandHandler : IRequestHandler<UpdateMaterialUnitCommand, Unit>
    {
        private IMaterialUnitRepository _materialUnitRepository;
        public UpdateMaterialUnitCommandHandler(IMaterialUnitRepository materialUnitRepository)
        {
            _materialUnitRepository = materialUnitRepository;
        }

        public async Task<Unit> Handle(UpdateMaterialUnitCommand request, CancellationToken cancellationToken)
        {
            // Validate unique name before updating
            if (await _materialUnitRepository.IsMaterialExistsByName(request.Name, request.Id, cancellationToken))
            {
                throw new ValidationException($"Material unit with name '{request.Name}' already exists.");
            }

            // Update the material unit in the database
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

            // Update the properties
            materialUnit.Name = request.Name;
            materialUnit.IsActive = request.IsActive;
            materialUnit.IsDeleted = request.IsDeleted;

            await _materialUnitRepository.UpdateAsync(materialUnit, cancellationToken);
            return Unit.Value;
        }
    }
}
