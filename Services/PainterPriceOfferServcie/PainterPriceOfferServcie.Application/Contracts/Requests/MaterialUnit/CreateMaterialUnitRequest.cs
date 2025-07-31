namespace PainterPriceOfferServcie.Application.Contracts.Requests.MaterialUnit
{
    public record CreateMaterialUnitRequest(
        string Name,
        string UserId
    );  
}
