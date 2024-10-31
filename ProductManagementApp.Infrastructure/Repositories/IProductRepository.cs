using ProductManagementApp.Domain.Entities;

namespace ProductManagementApp.Infrastructure.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IEnumerable<Product>> GetByCategoryAsync(string category);
    }
}