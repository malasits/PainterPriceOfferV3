using FluentValidation;

namespace PainterPriceOfferServcie.Application.Features.MaterialUnits.Commands.DeleteMaterialUnit
{
    public class DeleteMaterialUnitCommandValidator : AbstractValidator<DeleteMaterialUnitCommand>
    {
        public DeleteMaterialUnitCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Material unit ID is required.");
        }
    }
}
