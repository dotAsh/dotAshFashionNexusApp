using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotAshFashionNexus.Persistence.Repository.IRepository;
using dotAshFashionNexus.Persistence.Repository;
using dotAshFashionNexus.Service.IServices;
using dotAshFashionNexus.Service;
using Microsoft.Extensions.DependencyInjection;
using dotAshFashionNexus.Persistence.Data;
using Microsoft.EntityFrameworkCore;



namespace dotAshFashionNexus.Service
{
  
        public static class DependencyRegistration
        {
            public static void RegisterServiceDependencies(this IServiceCollection services, string connectionString,bool useInMemoryDatabase)
            {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();

                //if (useInMemoryDatabase){
                //        services.AddDbContext<ApplicationDbContext>(options =>
                //{
                //    options.UseInMemoryDatabase("InMemoryDatabaseName");
                //});
                // }
                //else
                //{
                services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseNpgsql(connectionString);
                });
                //}
            }
        }
    

}
