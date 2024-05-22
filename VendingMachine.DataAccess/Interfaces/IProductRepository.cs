using VendingMachine.DataAccess.Entities;

namespace Nagarro.VendingMachine.DataAccess
{
    public interface IProductRepository
    {
        public void Create(Product product);
        public List<Product> GetAll();
        public Product? GetById(Guid id);
        public void Update(Product product);
        public void Delete(Guid id);
    }
}