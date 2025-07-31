using BuildingBlocks.Persistence.Mongo;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using PainterPriceOfferServcie.Application.Interfaces.Persistence;
using PainterPriceOfferServcie.Domain.Entity;

namespace PainterPriceOfferServcie.Infrastructure.Persistence.Repositories
{
    public class MaterialUnitRepository : BaseRepository<MaterialUnit>, IMaterialUnitRepository
    {
        public MaterialUnitRepository(IConfiguration configuration) : base(configuration, nameof(MaterialUnit))
        {
        }

        public async Task<List<MaterialUnit>> GetAllByUserId(string userId, CancellationToken cancellationToken = default)
        {
            var userFilter = Builders<MaterialUnit>.Filter.Or(
                    Builders<MaterialUnit>.Filter.Eq(x => x.UserId, string.Empty),
                    Builders<MaterialUnit>.Filter.Eq(x => x.UserId, userId)
                );

            var finalFilter = Builders<MaterialUnit>.Filter.And(
                userFilter,
                Builders<MaterialUnit>.Filter.Eq(x => x.IsDeleted, false)
            );
            return await _collection.Find(finalFilter).ToListAsync(cancellationToken);
        }

        public async Task<List<MaterialUnit>> GetAllActiveByUserId(string userId, CancellationToken cancellationToken = default)
        {
            var userFilter = Builders<MaterialUnit>.Filter.Or(
                    Builders<MaterialUnit>.Filter.Eq(x => x.UserId, string.Empty),
                    Builders<MaterialUnit>.Filter.Eq(x => x.UserId, userId)
                );

            var finalFilter = Builders<MaterialUnit>.Filter.And(
                userFilter,
                Builders<MaterialUnit>.Filter.Eq(x => x.IsActive, true),
                Builders<MaterialUnit>.Filter.Eq(x => x.IsDeleted, false)
            );
            return await _collection.Find(finalFilter).ToListAsync(cancellationToken);
        }

        public async Task<bool> IsMaterialExistsByName(string name, string? id = null, CancellationToken cancellationToken = default)
        {
            var filters = new List<FilterDefinition<MaterialUnit>>
            {
                Builders<MaterialUnit>.Filter.Eq(x => x.Name, name),
                Builders<MaterialUnit>.Filter.Eq(x => x.IsDeleted, false)
            };

            if (!string.IsNullOrWhiteSpace(id))
            {
                var objectId = new ObjectId(id);
                filters.Add(Builders<MaterialUnit>.Filter.Ne("_id", objectId));
            }

            var filter = Builders<MaterialUnit>.Filter.And(filters);
            var materialUnit = await _collection.Find(filter).FirstOrDefaultAsync(cancellationToken);

            return materialUnit != null;
        }
    }
}
