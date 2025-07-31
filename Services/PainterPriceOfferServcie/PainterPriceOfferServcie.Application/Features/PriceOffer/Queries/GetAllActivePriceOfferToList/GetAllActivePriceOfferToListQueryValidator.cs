using FluentValidation;

namespace PainterPriceOfferServcie.Application.Features.PriceOffer.Queries.GetAllActivePriceOffer
{
    public class GetAllActivePriceOfferToListQueryValidator : AbstractValidator<GetAllActivePriceOfferToListQuery>
    {
        public GetAllActivePriceOfferToListQueryValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("UserId is required.");
        }
    }
}
