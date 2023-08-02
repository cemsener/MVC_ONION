using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_ONION_PROJECT.DOMAIN.CORE.BASE;
using MVC_ONION_PROJECT.DOMAIN.CORE.EntityTypeConfiguration;
using MVC_ONION_PROJECT.DOMAIN.ENTITIES;
using MVC_ONION_PROJECT.DOMAIN.EntityTypeConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_ONION_PROJECT.INFRASTRUCTURE.Configurations
{
    public class CategoryConfiguration : AuditableEntityConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(65);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(200);
            base.Configure(builder);
        }
    }
}
