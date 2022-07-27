using Microsoft.EntityFrameworkCore;
using ECommerce.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Persistence.Configurations;
using ECommerce.Application.Repositories.ProductRepository;
using ECommerce.Persistence.Repositories.ProductRepository;
using ECommerce.Application.Repositories.CustomerRepository;
using ECommerce.Persistence.Repositories.CustomerRepository;
using ECommerce.Persistence.Repositories.OrderRepository;
using ECommerce.Application.Repositories.OrderRepository;

namespace ECommerce.Persistence.DependencyResolvers
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<ProjectDbContext>(options => options.UseNpgsql(ConnectionString.Get()));

            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();

            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();

        }
    }
}
