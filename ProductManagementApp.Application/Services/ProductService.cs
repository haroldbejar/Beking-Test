using AutoMapper;
using ProductManagementApp.Domain.DTOs;
using ProductManagementApp.Domain.Entities;
using ProductManagementApp.Infrastructure.Repositories;

namespace ProductManagementApp.Application.Services
{
    public class ProductService : BaseService<ProductDto>, IProductService
    {
        private readonly IMapper _mapper;

        private readonly IProductRepository _productRepository;

        public ProductService(IMapper mapper, IBaseRepository<ProductDto> repository, IProductRepository productRepository)
            :base(repository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDto>> GetByCategoryAsync(string category)
        {
            var products = await _productRepository.GetByCategoryAsync(category);
            return _mapper.Map<List<ProductDto>>(products);
        }

        public override async Task InsertAsync(ProductDto productDto, string userRole) 
        {
            var validatedRole = ValidRoleBeforeInsert(userRole);
            if (!validatedRole) throw new UnauthorizedAccessException("Only admins can add products.");

            var product = _mapper.Map<Product>(productDto);
            await _productRepository.InsertAsync(product);
        }

        public bool ValidRoleBeforeInsert(string userRole)
        {
            if (userRole != "Admin") 
            {
                return false;
            }
            return true;
        }
    }
}