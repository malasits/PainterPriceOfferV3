using BuildingBlocks.Persistence.Mongo;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using PainterPriceOfferServcie.Application.Interfaces.Persistence;
using PainterPriceOfferServcie.Domain.Entity;

namespace PainterPriceOfferServcie.Infrastructure.Persistence.Repositories
{
    public class BaseSettingRepository : BaseRepository<BaseSettings>, IBaseSettingRepository
    {
        public BaseSettingRepository(IConfiguration configuration) : base(configuration, nameof(BaseSettings))
        {
        }

        public async Task<BaseSettings?> GetByUserIdAsync(string userId, CancellationToken cancellationToken = default)
        {
            var filter = Builders<BaseSettings>.Filter.Eq(x => x.UserId, userId);
            var settings = await _collection.Find(filter).FirstOrDefaultAsync(cancellationToken);
            return settings;
        }
    }
}
