using FluentValidation;

namespace PainterPriceOfferServcie.Application.Features.MaterialUnits.Commands.UpdateMaterialUnit
{
    public class UpdateMaterialUnitCommandValidator : AbstractValidator<UpdateMaterialUnitCommand>
    {
        public UpdateMaterialUnitCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Material unit ID is required.");
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Material unit name is required.");
        }
    }
}
