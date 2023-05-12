using ECommerce.Application.Contracts;
using ECommerce.Application.Services;
using ECommerce.Data;
using ECommerce.Data.Contract;
using ECommerce.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Api
{
    public static class ServiceExtension
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ECommerceContext>(opts =>
                opts.UseSqlServer(connString));
        }

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
             services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();

        }

    }
}
