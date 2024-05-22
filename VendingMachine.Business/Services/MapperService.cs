using VendingMachine.Business.DTOs;
using VendingMachine.DataAccess.Entities;

namespace VendingMachine.Business.Services
{
    public class MapperService
    {
        public Product ProductDtoToProduct(ProductDTO productDTO, Guid id)
        {
            return new Product
            {
                Id = id,
                Name = productDTO.Name,
                Description = productDTO.Description,
                Price = productDTO.Price,
                Quantity = productDTO.Quantity
            };
        }
        public ProductDTO ProductMapToProductDTO(Product product)
        {
            return new ProductDTO
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity
            };
        }
    }
}