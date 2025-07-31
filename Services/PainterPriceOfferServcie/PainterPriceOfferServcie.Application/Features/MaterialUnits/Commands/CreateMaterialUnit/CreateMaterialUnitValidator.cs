using FluentValidation;

namespace PainterPriceOfferServcie.Application.Features.MaterialUnits.Commands.CreateMaterialUnit
{
    public class CreateMaterialUnitValidator : AbstractValidator<CreateMaterialUnitCommand>
    {
        public CreateMaterialUnitValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Material unit name is required.");
            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("User ID is required.");
        }
    }
}
