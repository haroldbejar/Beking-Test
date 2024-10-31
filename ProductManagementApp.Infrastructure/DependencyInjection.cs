using Microsoft.Extensions.DependencyInjection;
using ProductManagementApp.Domain.Entities;
using ProductManagementApp.Infrastructure.Repositories;

namespace ProductManagementApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IBaseRepository<Product>, ProductRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}