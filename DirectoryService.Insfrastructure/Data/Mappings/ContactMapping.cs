using DirectoryService.Core.DomainClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryService.Application.Insfrastructure.Mappings
{
    public class ContactMapping : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(t => t.Firm).HasMaxLength(100);
            builder.Property(t => t.LastName).HasMaxLength(100);
            builder.Property(t => t.Name).HasMaxLength(100);

        }
    }
}
