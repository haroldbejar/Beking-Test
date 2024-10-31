using MongoDB.Driver;
using ProductManagementApp.Infrastructure.Data;

namespace ProductManagementApp.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;

        public BaseRepository(IProductManagementAppDatabaseSettings settings)
        {
            var mongoClient = new MongoClient(settings.ConnectionString);
            var dataBase = mongoClient.GetDatabase(settings.DatabaseName);
            var collectionName = settings.ProductCollection;
            _collection = dataBase.GetCollection<T>(collectionName);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task InsertAsync(T entity) 
        {
            await _collection.InsertOneAsync(entity);
        }

    }
}