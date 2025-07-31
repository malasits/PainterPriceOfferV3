using MediatR;
using PainterPriceOfferServcie.Application.Contracts.Responses.PriceOffer;

namespace PainterPriceOfferServcie.Application.Features.PriceOffer.Queries.GetAllActivePriceOffer
{
    public record GetAllActivePriceOfferToListQuery(string UserId) : IRequest<IEnumerable<PriceOfferListResponse>>;
}
