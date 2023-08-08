using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_ONION_PROJECT.DOMAIN.ENTITIES;
using MVC_ONION_PROJECT.DOMAIN.EntityTypeConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_ONION_PROJECT.INFRASTRUCTURE.Configurations
{
    public class AuthorConfiguraion : AuditableEntityConfiguration<Author>
    {
        public override void Configure(EntityTypeBuilder<Author> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(65);
            builder.Property(x => x.Surname).IsRequired().HasMaxLength(80);
            builder.Property(x => x.DateofBirth).IsRequired();
            base.Configure(builder);
        }
    }
}
