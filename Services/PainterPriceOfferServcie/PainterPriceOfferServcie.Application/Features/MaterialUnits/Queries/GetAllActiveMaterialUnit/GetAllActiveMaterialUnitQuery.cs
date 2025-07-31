using MediatR;
using PainterPriceOfferServcie.Application.Contracts.Responses.MaterialUnit;

namespace PainterPriceOfferServcie.Application.Features.MaterialUnits.Queries.GetAllActiveMaterialUnit
{
    public record GetAllActiveMaterialUnitQuery(string UserId) : IRequest<IEnumerable<MaterialUnitResponse>>;
}
