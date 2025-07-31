using PainterPriceOfferServcie.Application.Contracts.Requests.CostItem;

namespace PainterPriceOfferServcie.Application.Contracts.Requests.PriceOffer
{
    public record CreatePriceOfferRequest(
        string UserId,

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
        IEnumerable<CreateCostItemRequest> WorkWages,

        // Material wages
        int MaterialWageSummary,
        IEnumerable<CreateCostItemRequest> MaterialWages
    );
}
