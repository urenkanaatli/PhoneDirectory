using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReportService.Application.Repositories;
using ReportService.Application.UOW;
using ReportService.Insfrastructure.Data;
using ReportService.Insfrastructure.Repositories;
using ReportService.Insfrastructure.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Insfrastructure
{
    public static class DependencyInjection
    {

        public static void AddInfrasturucture(this IServiceCollection services, IConfiguration configuration)
        {
           

            bool useInMemoryDb = Convert.ToBoolean(configuration["UseInMemoryDb"]);

            if (useInMemoryDb)
            {
                services.AddDbContext<ReportDbContext>(ops =>
                {
                    ops.UseInMemoryDatabase("MemoryDbReport");
                });

            }
            else
            {
                services.AddDbContext<ReportDbContext>(ops =>
                {
                    ops.UseSqlServer(configuration.GetConnectionString("MyReportConnectionString"), ops =>
                    {
                        ops.MigrationsAssembly(typeof(ReportDbContext).Assembly.FullName);
                    });
                });
            }

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


        }
    }
}
