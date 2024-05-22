
namespace api_demo_business.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(object id) : base($"Product with id '{id}' was not found.") { }
    }
}