using MediatR;
using PainterPriceOfferServcie.Application.Contracts.Responses.WorkUnit;

namespace PainterPriceOfferServcie.Application.Features.WorkUnits.Queries.GetAllActiveWorkUnit
{
    public record GetAllActiveWorkUnitQuery(string UserId) : IRequest<IEnumerable<WorkUnitResponse>>;
}
