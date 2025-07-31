using MediatR;
using PainterPriceOfferServcie.Domain.Entity;

namespace PainterPriceOfferServcie.Application.Features.PriceOffer.Commands.UpdatePriceOffer
{
    public record UpdatePriceOfferCommand(
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
        IEnumerable<CostItem> WorkWages,

        // Material wages
        int MaterialWageSummary,
        IEnumerable<CostItem> MaterialWages,

        //Helper properties
        bool IsActive,
        bool IsDeleted
    ) : IRequest<Unit>;
}
