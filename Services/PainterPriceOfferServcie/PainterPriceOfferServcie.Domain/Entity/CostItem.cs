namespace PainterPriceOfferServcie.Domain.Entity
{
    public class CostItem
    {
        public required string Name { get; set; }
        public required int Count { get; set; }
        public required int UnitPrice { get; set; }
        public required int Summary { get; set; }
        public required string Unit { get; set; }
    }
}
