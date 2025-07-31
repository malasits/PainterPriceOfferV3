using FluentValidation;

namespace PainterPriceOfferServcie.Application.Features.WorkUnits.Commands.UpdateWorkUnit
{
    public class UpdateWorkUnitCommandValidator : AbstractValidator<UpdateWorkUnitCommand>
    {
        public UpdateWorkUnitCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Work unit ID is required.");
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Work unit name is required.");
        }
    }
}
