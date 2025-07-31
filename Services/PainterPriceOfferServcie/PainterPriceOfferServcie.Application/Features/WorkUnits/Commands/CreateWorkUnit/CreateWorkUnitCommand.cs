using MediatR;

namespace PainterPriceOfferServcie.Application.Features.WorkUnits.Commands.CreateWorkUnit
{
    public record CreateWorkUnitCommand(string Name, string UserId) : IRequest<Unit>;
}
