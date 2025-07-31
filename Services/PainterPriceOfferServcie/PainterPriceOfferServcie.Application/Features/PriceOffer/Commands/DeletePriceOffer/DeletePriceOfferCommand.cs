using MediatR;

namespace PainterPriceOfferServcie.Application.Features.PriceOffer.Commands.DeletePriceOffer
{
    public record DeletePriceOfferCommand(string Id) : IRequest<Unit>;
}
