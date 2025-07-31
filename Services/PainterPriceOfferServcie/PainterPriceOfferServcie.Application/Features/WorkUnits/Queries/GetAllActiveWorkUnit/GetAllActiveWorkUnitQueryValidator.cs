using FluentValidation;

namespace PainterPriceOfferServcie.Application.Features.WorkUnits.Queries.GetAllActiveWorkUnit
{
    public class GetAllActiveWorkUnitQueryValidator : AbstractValidator<GetAllActiveWorkUnitQuery>
    {
        public GetAllActiveWorkUnitQueryValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("User ID is required.");
        }
    }
}
