using VendingMachine.Business;
using VendingMachine.DataAccess.Entities;

namespace Nagarro.VendingMachine.DataAccess
{
    public class ProductRepository : IProductRepository
    {
        private static ICollection<Product> Products = new List<Product>
        {
            new Product {Id = Guid.NewGuid() , Name = "Coca Cola", Description = "Coca Cola 250ml", Price = 5, Quantity = 10},
            new Product {Id = Guid.NewGuid(), Name = "Pepsi", Description = "Pepsi 250ml", Price = 5, Quantity = 10},
            new Product {Id = Guid.NewGuid(), Name = "Lays", Description = "Lays 50g", Price = 10, Quantity = 10},
        };

        public List<Product> GetAll()
        {
            if (Products.ToList() == null)
            {
            }

            return Products.ToList();
        }

        public Product? GetById(Guid id)
        {
            Product? product = Products.FirstOrDefault(x => x.Id == id);
            return product;
        }

        public void Create(Product product)
        {
            if (Products.Any(p => p.Name == product.Name))
            {
                throw new Exception(product.Name + ErrorMessages.PRODUCT_ALREADY_EXISTS);
            }

            product.Id = Guid.NewGuid();
            Products.Add(product);
        }

        public void Update(Product product)
        {
            Product? productToUpdate = Products.FirstOrDefault(x => x.Id == product.Id);
            if (productToUpdate == null)
            {
                throw new Exception(product.Name + ErrorMessages.PRODUCT_DOES_NOT_EXIST);
            }

            productToUpdate.Name = product.Name;
            productToUpdate.Description = product.Description;
            productToUpdate.Price = product.Price;
            productToUpdate.Quantity = product.Quantity;
        }
        public void Delete(Guid id)
        {
            Product? product = Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                throw new Exception(ErrorMessages.NO_PRODUCTS_FOUND_WITH_THIS_ID + id);
            }

            Products.Remove(product);
        }


    }
}