using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nagarro.VendingMachine.DataAccess;
using VendingMachine.Business.Interfaces;
using VendingMachine.Business.Mappers;
using VendingMachine.Business.Services;
using VendingMachine.DataAccess;
using VendingMachine.DataAccess.Repositories;

namespace VendingMachine.Business
{
    public static class ServicesExtension
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProductProfile));
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, SQLiteProductRepository>();
        }
        public static void AddDbContext(this IServiceCollection services, string? connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new System.ArgumentNullException(nameof(connectionString));
            }

            services.AddDbContext<ProductDbContext>(options =>
             {
                 options.UseSqlite(connectionString);
             });
        }
    }
}
