using MediatR;
using PainterPriceOfferServcie.Application.Contracts.Responses.PriceOffer;

namespace PainterPriceOfferServcie.Application.Features.PriceOffer.Queries.GetPriceOfferById
{
    public record GetPriceOfferByIdQuery(string Id, string UserId) : IRequest<PriceOfferResponse>;
}
