using ProductManagementApp.Domain.DTOs;
using ProductManagementApp.Domain.Entities;

namespace ProductManagementApp.Application.Services
{
    public interface IProductService : IBaseService<ProductDto>
    {
        Task<IEnumerable<ProductDto>> GetByCategoryAsync(string category);

        bool ValidRoleBeforeInsert(string userRole);
    }
}