namespace PainterPriceOfferServcie.Application.Contracts.Responses.MaterialUnit
{
    public record MaterialUnitResponse(
        string Id,  
        string Name,
        bool IsActive,
        bool IsEnabledToEdit
        );
}
