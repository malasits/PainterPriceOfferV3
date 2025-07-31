using PainterPriceOfferServcie.Application.Contracts.Responses.CostItem;

namespace PainterPriceOfferServcie.Application.Contracts.Responses.PriceOffer
{
    public record PriceOfferResponse(
        string Id,

        // Document properties
        string DocumentTitle,
        string JobTitle,
        string? JobDescription,
        string? PriceOfferDescriptionHeader,
        string? WorkWageDescription,
        string? MaterialWageDescription,
        string? PriceOfferDescriptionFooter,
        DateTime PriceOfferDate,
        string NameOfSettlement,

        // Supplier properties
        string SupplierName,
        string SupplierAddress,
        string SupplierPhone,
        string SupplierEmail,

        // Customer properties
        string CustomerName,
        string CustomerAddress,
        string CustomerPhone,
        string CustomerEmail,
        bool UseCustomerData,

        // AFA properties
        bool IsAfa,
        string? AfaText,
        int AfaKey,
        string? LocalAfaText,
        string? LocalNotAfaText,

        // Work wages
        int WorkWageSummary,
        IEnumerable<CostItemResponse> WorkWages,

        // Material wages
        int MaterialWageSummary,
        IEnumerable<CostItemResponse> MaterialWages
    );
}
