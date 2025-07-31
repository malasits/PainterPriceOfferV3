using MediatR;

namespace PainterPriceOfferServcie.Application.Features.MaterialUnits.Commands.CreateMaterialUnit
{
    public record CreateMaterialUnitCommand(string Name, string UserId) : IRequest<Unit>;
}
