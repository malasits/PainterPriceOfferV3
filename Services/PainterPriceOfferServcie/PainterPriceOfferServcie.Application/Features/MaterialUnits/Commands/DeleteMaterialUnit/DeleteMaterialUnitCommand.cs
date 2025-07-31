using MediatR;

namespace PainterPriceOfferServcie.Application.Features.MaterialUnits.Commands.DeleteMaterialUnit
{
    public record DeleteMaterialUnitCommand(string Id) : IRequest<Unit>;
}
