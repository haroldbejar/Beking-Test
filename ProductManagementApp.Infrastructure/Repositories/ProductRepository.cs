using MongoDB.Driver;
using ProductManagementApp.Domain.Entities;
using ProductManagementApp.Infrastructure.Data;

namespace ProductManagementApp.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly IMongoCollection<Product> _productCollection;

        public ProductRepository(IProductManagementAppDatabaseSettings settings) : base(settings)
        {
            var mongoClient = new MongoClient(settings.ConnectionString);
            var dataBase = mongoClient.GetDatabase(settings.DatabaseName);
            _productCollection = dataBase.GetCollection<Product>(settings.ProductCollection);
        }

        public async Task<IEnumerable<Product>> GetByCategoryAsync(string category)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Category, category);
            return await _productCollection.Find(filter).ToListAsync();

        }
    }
}