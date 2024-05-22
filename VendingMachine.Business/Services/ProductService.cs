using api_demo_business.Exceptions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Nagarro.VendingMachine.DataAccess;
using VendingMachine.Business.DTOs;
using VendingMachine.Business.Interfaces;
using VendingMachine.DataAccess.Entities;

namespace VendingMachine.Business.Services
{
    public class ProductService : IProductService
    {
        private IMapper _mapper;
        private IProductRepository _productRepository;
        private readonly ILogger _logger;

        public ProductService(IProductRepository productRepository, IMapper mapper, ILogger<ProductService> logger)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public void CreateProduct(ProductDTO productDto)
        {
            Product product = _mapper.Map<Product>(productDto);
            _logger.LogInformation($"Created a product entity with the id: {product.Id}, name: {product.Name}");
            _productRepository.Create(product);

        }
        public List<ProductDTO> GetProducts()
        {
            _logger.LogInformation("Getting the list of products");
            List<Product> products = _productRepository.GetAll();

            List<ProductDTO> productDTOs = new List<ProductDTO>();
            foreach (var product in products)
            {
                productDTOs.Add(_mapper.Map<ProductDTO>(product));
            }

            return productDTOs;
        }
        public ProductDTO GetProduct(Guid id)
        {
            List<Product> products = _productRepository.GetAll();
            Product? product = _productRepository.GetById(id);
            if(product == null)
            {
                throw new ProductNotFoundException(id);
            }

            _logger.LogInformation($"Getting a product entity with the id: {product.Id}, name: {product.Name}");
            return _mapper.Map<ProductDTO>(product);
        }
        public void UpdateProduct(Guid id, ProductDTO updatedProduct)
        {
            List<Product> products = _productRepository.GetAll();
            Product? product = _productRepository.GetById(id);
            if(product == null)
            {
                throw new ProductNotFoundException(id);
            }

            product.Name = updatedProduct.Name;
            product.Description = updatedProduct.Description;
            product.Price = updatedProduct.Price;
            product.Quantity = updatedProduct.Quantity;

            _logger.LogInformation($"Updated a product entity with the id: {product.Id}, name: {product.Name}");
            _productRepository.Update(product);

        }
        public void DeleteProduct(Guid id)
        {
            Product? product = _productRepository.GetById(id);
            if(product == null)
            {
                throw new ProductNotFoundException(id);
            }

            _logger.LogInformation($"Deleted a product entity with the id: {product.Id}, name: {product.Name}");
            _productRepository.Delete(id);

        }


    }
}