using FluentValidation;

namespace PainterPriceOfferServcie.Application.Features.MaterialUnits.Queries.GetAllActiveMaterialUnit
{
    public class GetAllActiveMaterialUnitQueryValidator : AbstractValidator<GetAllActiveMaterialUnitQuery>
    {
        public GetAllActiveMaterialUnitQueryValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("User ID is required.");
        }
    }
}
