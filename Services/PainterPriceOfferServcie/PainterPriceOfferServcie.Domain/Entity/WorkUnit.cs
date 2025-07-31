using BuildingBlocks.Domain;

namespace PainterPriceOfferServcie.Domain.Entity
{
    public class WorkUnit : BaseEntity
    {
        public string? UserId { get; set; }
        public required string Name { get; set; }
        public bool IsEnabledToEdit { get; set; }
    }
}
