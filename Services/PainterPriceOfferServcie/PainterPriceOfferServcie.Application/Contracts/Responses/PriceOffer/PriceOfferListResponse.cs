namespace PainterPriceOfferServcie.Application.Contracts.Responses.PriceOffer
{
    public record PriceOfferListResponse(
        string Id,

        // Document properties
        string DocumentTitle,
        string JobTitle,

        // AFA properties
        bool IsAfa,
        int AfaKey,

        //Helper properties
        bool IsActive,
        DateTime Created,
        DateTime Updated
    );
}
