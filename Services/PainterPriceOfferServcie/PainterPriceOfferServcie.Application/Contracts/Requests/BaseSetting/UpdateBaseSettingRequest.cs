namespace PainterPriceOfferServcie.Application.Contracts.Requests.BaseSetting
{
    public record UpdateBaseSettingRequest(
        string Id,
        string DocumentTitle,
        bool DefaultAfaSelected,
        string AfaText,
        string NotAfaText,
        int AfaKey
    );
}
