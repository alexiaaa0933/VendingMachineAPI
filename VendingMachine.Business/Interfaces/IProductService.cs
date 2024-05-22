using VendingMachine.Business.DTOs;

namespace VendingMachine.Business.Interfaces
{
    public interface IProductService
    {
        public void CreateProduct(ProductDTO product);
        public List<ProductDTO> GetProducts();
        public ProductDTO GetProduct(Guid id);
        public void UpdateProduct(Guid id, ProductDTO updatedProduct);
        public void DeleteProduct(Guid id);
    }
}