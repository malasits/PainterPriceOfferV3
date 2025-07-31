using MediatR;

namespace PainterPriceOfferServcie.Application.Features.WorkUnits.Commands.UpdateWorkUnit
{
    public record UpdateWorkUnitCommand(
    string Id,
    string Name,
    bool IsActive,
    bool IsDeleted
    ) : IRequest<Unit>;
}
