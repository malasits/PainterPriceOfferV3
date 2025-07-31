using FluentValidation;

namespace PainterPriceOfferServcie.Application.Features.PriceOffer.Commands.DeletePriceOffer
{
    public class DeletePriceOfferCommandValidator : AbstractValidator<DeletePriceOfferCommand>
    {
        public DeletePriceOfferCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Price Offer ID is required.");
        }
    }
}
