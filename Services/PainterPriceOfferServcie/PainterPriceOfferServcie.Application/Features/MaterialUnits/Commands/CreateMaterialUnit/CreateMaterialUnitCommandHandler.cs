using FluentValidation;
using MediatR;
using PainterPriceOfferServcie.Application.Interfaces.Persistence;
using PainterPriceOfferServcie.Domain.Entity;

namespace PainterPriceOfferServcie.Application.Features.MaterialUnits.Commands.CreateMaterialUnit
{
    public class CreateMaterialUnitCommandHandler : IRequestHandler<CreateMaterialUnitCommand, Unit>
    {
        private readonly IMaterialUnitRepository _materialUnitRepository;
        public CreateMaterialUnitCommandHandler(IMaterialUnitRepository materialUnitRepository)
        {
            _materialUnitRepository = materialUnitRepository;
        }

        public async Task<Unit> Handle(CreateMaterialUnitCommand request, CancellationToken cancellationToken)
        {
            //Validate unique name before saving
            if (await _materialUnitRepository.IsMaterialExistsByName(request.Name, cancellationToken: cancellationToken))
            {
                throw new ValidationException($"Material unit with name '{request.Name}' already exists.");
            }

            //Save the material unit to the database
            await _materialUnitRepository.AddAsync(new MaterialUnit
            {
                Name = request.Name,
                UserId = request.UserId,
                IsEnabledToEdit = true
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
