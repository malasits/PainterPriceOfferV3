namespace PainterPriceOfferServcie.Application.Contracts.Responses.WorkUnit
{
    public record WorkUnitResponse(
    string Id,
    string Name,
    bool IsActive,
    bool IsEnabledToEdit
    );
}
