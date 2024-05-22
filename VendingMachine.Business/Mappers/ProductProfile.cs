using VendingMachine.Business.DTOs;
using VendingMachine.DataAccess.Entities;
using AutoMapper;

namespace VendingMachine.Business.Mappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
        }
    }
}