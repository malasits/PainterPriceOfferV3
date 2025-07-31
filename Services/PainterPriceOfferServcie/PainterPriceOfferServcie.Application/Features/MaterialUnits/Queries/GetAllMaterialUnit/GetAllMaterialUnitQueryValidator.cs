using FluentValidation;

namespace PainterPriceOfferServcie.Application.Features.MaterialUnits.Queries.GetAllMaterialUnit
{
    public class GetAllMaterialUnitQueryValidator : AbstractValidator<GetAllMaterialUnitQuery>
    {
        public GetAllMaterialUnitQueryValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("User ID is required.");
        }
    }
}
