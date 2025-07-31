namespace PainterPriceOfferServcie.Application.Contracts.Responses.BaseSetting
{
    public record BaseSettingResponse(
        string Id,
        string DocumentTitle,
        bool DefaultAfaSelected,
        string AfaText,
        string NotAfaText,
        int AfaKey
    );
}
