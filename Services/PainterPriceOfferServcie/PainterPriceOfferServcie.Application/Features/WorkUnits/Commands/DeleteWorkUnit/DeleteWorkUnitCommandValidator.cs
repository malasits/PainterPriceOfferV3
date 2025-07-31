using FluentValidation;

namespace PainterPriceOfferServcie.Application.Features.WorkUnits.Commands.DeleteWorkUnit
{
    public class DeleteWorkUnitCommandValidator : AbstractValidator<DeleteWorkUnitCommand>
    {
        public DeleteWorkUnitCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Work unit ID is required.");
        }
    }
}
