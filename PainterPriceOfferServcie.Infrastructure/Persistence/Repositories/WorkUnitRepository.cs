using BuildingBlocks.Persistence.Mongo;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using PainterPriceOfferServcie.Application.Interfaces.Persistence;
using PainterPriceOfferServcie.Domain.Entity;

namespace PainterPriceOfferServcie.Infrastructure.Persistence.Repositories
{
    public class WorkUnitRepository : BaseRepository<WorkUnit>, IWorkUnitRepository
    {
        public WorkUnitRepository(IConfiguration configuration) : base(configuration, nameof(WorkUnit))
        {
        }

        public async Task<List<WorkUnit>> GetAllByUserId(string userId, CancellationToken cancellationToken = default)
        {
            var userFilter = Builders<WorkUnit>.Filter.Or(
                    Builders<WorkUnit>.Filter.Eq(x => x.UserId, string.Empty),
                    Builders<WorkUnit>.Filter.Eq(x => x.UserId, userId)
                );

            var finalFilter = Builders<WorkUnit>.Filter.And(
                userFilter,
                Builders<WorkUnit>.Filter.Eq(x => x.IsDeleted, false)
            );
            return await _collection.Find(finalFilter).ToListAsync(cancellationToken);
        }

        public async Task<List<WorkUnit>> GetAllActiveByUserId(string userId, CancellationToken cancellationToken = default)
        {
            var userFilter = Builders<WorkUnit>.Filter.Or(
                    Builders<WorkUnit>.Filter.Eq(x => x.UserId, string.Empty),
                    Builders<WorkUnit>.Filter.Eq(x => x.UserId, userId)
                );

            var finalFilter = Builders<WorkUnit>.Filter.And(
                userFilter,
                Builders<WorkUnit>.Filter.Eq(x => x.IsActive, true),
                Builders<WorkUnit>.Filter.Eq(x => x.IsDeleted, false)
            );
            return await _collection.Find(finalFilter).ToListAsync(cancellationToken);
        }

        public async Task<bool> IsWorkUnitExistsByName(string name, string? id = null, CancellationToken cancellationToken = default)
        {
            var filters = new List<FilterDefinition<WorkUnit>>
            {
                Builders<WorkUnit>.Filter.Eq(x => x.Name, name),
                Builders<WorkUnit>.Filter.Eq(x => x.IsDeleted, false)
            };

            if (!string.IsNullOrWhiteSpace(id))
            {
                var objectId = new ObjectId(id);
                filters.Add(Builders<WorkUnit>.Filter.Ne("_id", objectId));
            }

            var filter = Builders<WorkUnit>.Filter.And(filters);
            var workUnitUnit = await _collection.Find(filter).FirstOrDefaultAsync(cancellationToken);

            return workUnitUnit != null;
        }
    }
}
