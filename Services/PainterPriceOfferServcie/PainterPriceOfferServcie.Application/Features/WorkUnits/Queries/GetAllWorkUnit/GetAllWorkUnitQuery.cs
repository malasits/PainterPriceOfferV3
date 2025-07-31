using MediatR;
using PainterPriceOfferServcie.Application.Contracts.Responses.WorkUnit;

namespace PainterPriceOfferServcie.Application.Features.WorkUnits.Queries.GetAllWorkUnit
{
    public record GetAllWorkUnitQuery(string UserId) : IRequest<IEnumerable<WorkUnitResponse>>;
}
