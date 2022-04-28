using Microsoft.EntityFrameworkCore;
using ReportService.Core.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Insfrastructure.Data
{
    public class ReportDbContext : DbContext
    {
        public DbSet<Report> Reports { get; set; }
  
        public ReportDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfigurationsFromAssembly(typeof(ReportDbContext).Assembly);

            base.OnModelCreating(builder);
        }


    }
}
