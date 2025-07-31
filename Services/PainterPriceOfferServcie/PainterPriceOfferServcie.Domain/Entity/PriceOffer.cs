using BuildingBlocks.Domain;

namespace PainterPriceOfferServcie.Domain.Entity
{
    public class PriceOffer : BaseEntity
    {
        public required string UserId { get; set; }

        //Document properties
        public required string DocumentTitle { get; set; }
        public required string JobTitle { get; set; }
        public string? JobDescription { get; set; }
        public string? PriceOfferDescriptionHeader { get; set; }
        public string? WorkWageDescription { get; set; }
        public string? MaterialWageDescription { get; set; }
        public string? PriceOfferDescriptionFooter { get; set; }
        public required DateTime PriceOfferDate { get; set; } = DateTime.Now;
        public required string NameOfSettlement { get; set; }

        //Supplier properties
        public required string SupplierName { get; set; }
        public required string SupplierAddress { get; set; }
        public required string SupplierPhone { get; set; }
        public required string SupplierEmail { get; set; }

        //Customer properties
        public required string CustomerName { get; set; }
        public required string CustomerAddress { get; set; }
        public required string CustomerPhone { get; set; }
        public required string CustomerEmail { get; set; }
        public bool UseCustomerData { get; set; }

        //AFA properties
        public bool IsAfa { get; set; }
        public string? AfaText { get; set; }
        public int AfaKey { get; set; }
        public string? LocalAfaText { get; set; }
        public string? LocalNotAfaText { get; set; }

        //Work wages
        public int WorkWageSummary { get; set; }
        public IEnumerable<CostItem> WorkWages { get; set; } = new List<CostItem>();

        //Material wages
        public int MaterialWageSummary { get; set; }
        public IEnumerable<CostItem> MaterialWages { get; set; } = new List<CostItem>();
    }
}
