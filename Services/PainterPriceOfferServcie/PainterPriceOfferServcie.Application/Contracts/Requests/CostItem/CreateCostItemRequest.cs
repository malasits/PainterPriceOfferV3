namespace PainterPriceOfferServcie.Application.Contracts.Requests.CostItem
{
    public record CreateCostItemRequest(
        string Name,
        int Count,
        int UnitPrice,
        int Summary,
        string Unit
    );
}
