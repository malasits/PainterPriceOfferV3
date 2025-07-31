namespace PainterPriceOfferServcie.Application.Contracts.Requests.MaterialUnit
{
    public record UpdateMaterialUnitRequest(
        string Id,
        string Name,
        bool IsActive
    );
}
