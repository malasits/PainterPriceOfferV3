using FluentValidation;

namespace PainterPriceOfferServcie.Application.Features.PriceOffer.Queries.GetPriceOfferById
{
    public class GetPriceOfferByIdQueryValidator : AbstractValidator<GetPriceOfferByIdQuery>
    {
        public GetPriceOfferByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id is required.");

            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("UserId is required.");
        }
    }
}
