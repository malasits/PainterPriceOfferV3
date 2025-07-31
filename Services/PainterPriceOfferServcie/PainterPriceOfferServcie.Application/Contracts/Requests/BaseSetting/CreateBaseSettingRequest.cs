namespace PainterPriceOfferServcie.Application.Contracts.Requests.BaseSetting
{
    public record CreateBaseSettingRequest(
        string UserId,
        string DocumentTitle,
        bool DefaultAfaSelected,
        string AfaText,
        string NotAfaText,
        int AfaKey
    );
}
