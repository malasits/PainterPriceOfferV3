using BuildingBlocks.Persistence.Mongo;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using PainterPriceOfferServcie.Application.Interfaces.Persistence;
using PainterPriceOfferServcie.Domain.Entity;

namespace PainterPriceOfferServcie.Infrastructure.Persistence.Repositories
{
    public class PriceOfferRepository : BaseRepository<PriceOffer>, IPriceOfferRepository
    {
        public PriceOfferRepository(IConfiguration configuration) : base(configuration, nameof(PriceOffer))
        {
        }

        public async Task<List<PriceOffer>> GetAllActiveByUserIdToList(string userId, CancellationToken cancellationToken = default)
        {
            var filter = Builders<PriceOffer>.Filter.And(
                Builders<PriceOffer>.Filter.Eq(x => x.UserId, userId),
                Builders<PriceOffer>.Filter.Eq(x => x.IsActive, true),
                Builders<PriceOffer>.Filter.Eq(x => x.IsDeleted, false)
            );

            var projection = Builders<PriceOffer>.Projection
                .Include(x => x.Id)
                .Include(x => x.DocumentTitle)
                .Include(x => x.JobTitle)
                .Include(x => x.IsAfa)
                .Include(x => x.AfaKey)
                .Include(x => x.Created)
                .Include(x => x.Updated)
                .Include(x => x.IsActive);

            var result = await _collection
                .Find(filter)
                .Project<PriceOffer>(projection)
                .ToListAsync(cancellationToken);

            return result;
        }

        public async Task<PriceOffer> GetByIdAndUserId(string id, string userId, CancellationToken cancellationToken = default)
        {
            var objectId = new ObjectId(id);
            var filter = Builders<PriceOffer>.Filter.And(
                Builders<PriceOffer>.Filter.Eq(x => x.Id, objectId.ToString()),
                Builders<PriceOffer>.Filter.Eq(x => x.UserId, userId),
                Builders<PriceOffer>.Filter.Eq(x => x.IsDeleted, false)
            );
            return await _collection.Find(filter).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
