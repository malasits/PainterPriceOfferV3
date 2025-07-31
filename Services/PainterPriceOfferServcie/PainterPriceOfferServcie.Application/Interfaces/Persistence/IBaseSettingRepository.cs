using BuildingBlocks.Persistence.Mongo;
using PainterPriceOfferServcie.Domain.Entity;

namespace PainterPriceOfferServcie.Application.Interfaces.Persistence
{
    public interface IBaseSettingRepository : IRepository<BaseSettings>
    {
        Task<BaseSettings?> GetByUserIdAsync(string userId, CancellationToken cancellationToken = default);
    }
}
