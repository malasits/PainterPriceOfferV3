namespace PainterPriceOfferServcie.Application.Models
{
    public record BaseSettings(
        string DocumentTitle,
        string Address,
        string PhoneNumber,
        string Email,
        bool IsAfa,
        string AfaText,
        string NotAfaText,
        string NameOfSettlement,
        int AfaKey
    );
}
