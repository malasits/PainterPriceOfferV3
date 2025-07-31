using BuildingBlocks.Persistence.Mongo;
using PainterPriceOfferServcie.Domain.Entity;

namespace PainterPriceOfferServcie.Application.Interfaces.Persistence
{
    public interface IPriceOfferRepository : IRepository<PriceOffer>
    {
        Task<List<PriceOffer>> GetAllActiveByUserIdToList(string userId, CancellationToken cancellationToken = default);
        Task<PriceOffer> GetByIdAndUserId(string id, string userId, CancellationToken cancellationToken = default);
    }
}
