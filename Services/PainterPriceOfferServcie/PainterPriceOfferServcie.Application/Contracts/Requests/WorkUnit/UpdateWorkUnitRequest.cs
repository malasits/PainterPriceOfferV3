namespace PainterPriceOfferServcie.Application.Contracts.Requests.WorkUnit
{
    public record UpdateWorkUnitRequest(
    string Id,
    string Name,
    bool IsActive
    );
}
