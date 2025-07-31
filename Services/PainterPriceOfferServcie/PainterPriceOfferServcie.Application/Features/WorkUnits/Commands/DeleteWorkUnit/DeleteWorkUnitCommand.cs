using MediatR;

namespace PainterPriceOfferServcie.Application.Features.WorkUnits.Commands.DeleteWorkUnit
{
    public record DeleteWorkUnitCommand(string Id) : IRequest<Unit>;
}
