using DirectoryService.Core.DomainClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryService.Insfrastructure.Data
{
    public class ContactDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactInformation> ContactInformations { get; set; }

        public ContactDbContext(DbContextOptions options) : base(options)
        {




        }

        protected override void OnModelCreating(ModelBuilder builder)
        {



            builder.ApplyConfigurationsFromAssembly(typeof(ContactDbContext).Assembly);

            base.OnModelCreating(builder);
        }


    }
}
