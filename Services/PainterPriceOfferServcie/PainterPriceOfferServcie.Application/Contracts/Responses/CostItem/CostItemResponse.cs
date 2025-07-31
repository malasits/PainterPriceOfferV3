namespace PainterPriceOfferServcie.Application.Contracts.Responses.CostItem
{
    public record CostItemResponse(
        string Name,
        int Count,
        int UnitPrice,
        int Summary,
        string Unit
        );
}