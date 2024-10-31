using AutoMapper;
using ProductManagementApp.Domain.DTOs;
using ProductManagementApp.Domain.Entities;

namespace ProductManagementApp.Domain.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
        }
    }
}