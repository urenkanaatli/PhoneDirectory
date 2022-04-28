using DirectoryService.Application.Repositories;
using DirectoryService.Application.UOW;
using DirectoryService.Insfrastructure.Data;
using DirectoryService.Insfrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryService.Insfrastructure
{
    public static class DependencyInjection
    {

        public static void AddInfrasturucture(this IServiceCollection services, IConfiguration configuration)
        {
           

            bool useInMemoryDb = Convert.ToBoolean(configuration["UseInMemoryDb"]);

            if (useInMemoryDb)
            {
                services.AddDbContext<ContactDbContext>(ops =>
                {
                    ops.UseInMemoryDatabase("MemoryDb");
                });

            }
            else
            {
                services.AddDbContext<ContactDbContext>(ops =>
                {
                    ops.UseSqlServer(configuration.GetConnectionString("ContactDbConnectionString"), ops =>
                    {
                        ops.MigrationsAssembly(typeof(ContactDbContext).Assembly.FullName);
                    });
                });
            }

          

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IContactRepository), typeof(ContactRepository));
            services.AddScoped<IUnitOfWork, UnitOfWork>();


        }
    }
}
