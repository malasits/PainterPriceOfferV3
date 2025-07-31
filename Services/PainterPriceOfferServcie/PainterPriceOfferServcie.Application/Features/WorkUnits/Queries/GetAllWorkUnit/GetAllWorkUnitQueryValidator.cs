using FluentValidation;

namespace PainterPriceOfferServcie.Application.Features.WorkUnits.Queries.GetAllWorkUnit
{
    public class GetAllWorkUnitQueryValidator : AbstractValidator<GetAllWorkUnitQuery>
    {
        public GetAllWorkUnitQueryValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("User ID is required.");
        }
    }
}
