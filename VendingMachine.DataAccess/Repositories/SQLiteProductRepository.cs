using Nagarro.VendingMachine.DataAccess;
using VendingMachine.Business;
using VendingMachine.DataAccess.Entities;

namespace VendingMachine.DataAccess.Repositories
{
    public class SQLiteProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public SQLiteProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public void Create(Product product)
        {
            if (_context.Products.Any(p => p.Name == product.Name))
            {
                throw new Exception(product.Name + ErrorMessages.PRODUCT_ALREADY_EXISTS);
            }

            product.Id = Guid.NewGuid();
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            Product? product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                throw new Exception(ErrorMessages.NO_PRODUCTS_FOUND_WITH_THIS_ID + id);
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

        }

        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            products = _context.Products.ToList();
            if (products == null)
            {
                throw new Exception(ErrorMessages.NO_PRODUCTS_FOUND);
            }
            return products;
        }

        public Product? GetById(Guid id)
        {
            Product? product = _context.Products.FirstOrDefault(x => x.Id == id);
            return product;
        }

        public void Update(Product product)
        {
            Product? productFromDb = _context.Products.FirstOrDefault(x => x.Id == product.Id);
            if (productFromDb == null)
            {
                throw new Exception(product.Name + ErrorMessages.PRODUCT_DOES_NOT_EXIST);
            }

            productFromDb.Name = product.Name;
            productFromDb.Description = product.Description;
            productFromDb.Price = product.Price;
            productFromDb.Quantity = product.Quantity;

            _context.Products.Update(productFromDb);
            _context.SaveChanges();
        }
    }
}
