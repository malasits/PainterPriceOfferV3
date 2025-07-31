namespace PainterPriceOfferServcie.Application.Contracts.Requests.WorkUnit
{
    public record CreateWorkUnitRequest(
        string Name,
        string UserId
    );
}
