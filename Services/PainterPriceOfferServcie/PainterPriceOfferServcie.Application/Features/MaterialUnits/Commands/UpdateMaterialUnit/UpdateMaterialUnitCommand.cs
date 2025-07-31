using MediatR;

namespace PainterPriceOfferServcie.Application.Features.MaterialUnits.Commands.UpdateMaterialUnit
{
    public record UpdateMaterialUnitCommand(
        string Id,
        string Name, 
        bool IsActive, 
        bool IsDeleted
        ) : IRequest<Unit>;
}

