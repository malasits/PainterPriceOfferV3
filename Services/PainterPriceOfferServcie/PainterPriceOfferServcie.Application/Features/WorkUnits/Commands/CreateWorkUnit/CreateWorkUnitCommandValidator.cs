using FluentValidation;

namespace PainterPriceOfferServcie.Application.Features.WorkUnits.Commands.CreateWorkUnit
{
    public class CreateWorkUnitCommandValidator : AbstractValidator<CreateWorkUnitCommand>
    {
        public CreateWorkUnitCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Work unit name is required.");
            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("User ID is required.");
        }
    }
}
