using BuildingBlocks.Domain;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BuildingBlocks.Persistence.Mongo
{
    public abstract class BaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly IMongoCollection<TEntity> _collection;

        protected BaseRepository(IConfiguration configuration, string collectionName)
        {
            var mongoClient = new MongoClient(configuration["MongoDB:ConnectionString"]);
            var mongoDatabase = mongoClient.GetDatabase(configuration["MongoDB:DatabaseName"]);
            _collection = mongoDatabase.GetCollection<TEntity>(collectionName);
        }

        public async Task<TEntity?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var objectId = new ObjectId(id.ToString());
            var entity = await _collection.Find(Builders<TEntity>.Filter.Eq("_id", objectId)).FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
                return null;

            var isDeletedProp = typeof(TEntity).GetProperty("IsDeleted");
            if (isDeletedProp != null && (bool)isDeletedProp.GetValue(entity)!)
                return null;

            return entity;
        }

        public async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            if (HasIsDeletedProperty())
            {
                var filter = Builders<TEntity>.Filter.Eq("IsDeleted", false);
                return await _collection.Find(filter).ToListAsync(cancellationToken);
            }

            return await _collection.Find(_ => true).ToListAsync(cancellationToken);
        }

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _collection.InsertOneAsync(entity, cancellationToken: cancellationToken);
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var updatedProp = typeof(TEntity).GetProperty("Updated");
            if (updatedProp != null)
                updatedProp.SetValue(entity, DateTime.UtcNow);

            var filter = Builders<TEntity>.Filter.Eq(x => x.Id, entity.Id);
            await _collection.ReplaceOneAsync(filter, entity, cancellationToken: cancellationToken);
        }

        public void Remove(TEntity entity)
        {
            var isDeletedProp = typeof(TEntity).GetProperty("IsDeleted");
            if (isDeletedProp != null)
            {
                isDeletedProp.SetValue(entity, true);

                var updatedProp = typeof(TEntity).GetProperty("Updated");
                if (updatedProp != null)
                    updatedProp.SetValue(entity, DateTime.UtcNow);

                var filter = Builders<TEntity>.Filter.Eq(x => x.Id, entity.Id);
                _collection.ReplaceOne(filter, entity);
            }
            else
            {
                var filter = Builders<TEntity>.Filter.Eq(x => x.Id, entity.Id);
                _collection.DeleteOne(filter);
            }
        }

        private static bool HasIsDeletedProperty()
        {
            return typeof(TEntity).GetProperty("IsDeleted") != null;
        }
    }
}
