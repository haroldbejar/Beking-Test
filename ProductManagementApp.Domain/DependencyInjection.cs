using Microsoft.Extensions.DependencyInjection;
using ProductManagementApp.Domain.Profiles;

namespace ProductManagementApp.Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAutoMapperConfig(this IServiceCollection services) 
        {
            services.AddAutoMapper(
                typeof(ProductProfile)
            );

            return services;
        }
    }
}