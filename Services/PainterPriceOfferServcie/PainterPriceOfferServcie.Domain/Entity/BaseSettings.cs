using BuildingBlocks.Domain;

namespace PainterPriceOfferServcie.Domain.Entity
{
    public class BaseSettings : BaseEntity
    {
        //public required string Address { get; set; }//ID tokenből fog jönni
        //public required string PhoneNumber { get; set; }//ID tokenből fog jönni
        //public required string Email { get; set; }//ID tokenből fog jönni
        //public required string NameOfSettlement { get; set; }

        public string? UserId { get; set; }
        public required string DocumentTitle { get; set; }
        public bool DefaultAfaSelected { get; set; }
        public required string AfaText { get; set; }
        public required string NotAfaText { get; set; }
        public required int AfaKey { get; set; }
    }
}
