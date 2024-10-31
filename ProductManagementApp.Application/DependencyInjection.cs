using Microsoft.Extensions.DependencyInjection;
using ProductManagementApp.Application.Services;
using ProductManagementApp.Domain.DTOs;
using ProductManagementApp.Domain.Entities;

namespace ProductManagementApp.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped<IBaseService<ProductDto>, BaseService<ProductDto>>();
            services.AddScoped<IProductService, ProductService>();
            return services;
        }
    }
}