using MediatR;
using PainterPriceOfferServcie.Application.Contracts.Responses.MaterialUnit;

namespace PainterPriceOfferServcie.Application.Features.MaterialUnits.Queries.GetAllMaterialUnit
{
    public record GetAllMaterialUnitQuery(string UserId) : IRequest<IEnumerable<MaterialUnitResponse>>;
}
