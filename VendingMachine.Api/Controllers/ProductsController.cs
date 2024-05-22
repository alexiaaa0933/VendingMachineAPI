using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using VendingMachine.Business.DTOs;
using VendingMachine.Business.Interfaces;

namespace VendingMachine.Api.Controllers
{
    [ApiVersion(1)]
    [ApiVersion(2)]
    [ApiController]
    [Route("api/v{v:apiVersion}/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [MapToApiVersion(1)]
        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductDTO product)
        {
            _productService.CreateProduct(product);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            List<ProductDTO> allProducts = _productService.GetProducts();
            return Ok(allProducts);
        }

        [MapToApiVersion(1)]
        [HttpGet("{id}")]
        public IActionResult GetProductById(Guid id)
        {
            ProductDTO product = _productService.GetProduct(id);
            return Ok(product);
        }

        [MapToApiVersion(2)]
        [HttpPut]
        public IActionResult UpdateProduct(Guid id, [FromBody] ProductDTO product)
        {
            _productService.UpdateProduct(id, product);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(Guid id)
        {
            _productService.DeleteProduct(id);
            return Ok();
        }
    }
}