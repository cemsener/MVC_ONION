using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MVC_ONION_PROJECT.DOMAIN.CORE.BASE;
using MVC_ONION_PROJECT.DOMAIN.EntityTypeConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_ONION_PROJECT.DOMAIN.CORE.EntityTypeConfiguration
{
    public class BaseUserConfiguration<T> : AuditableEntityConfiguration<T> where T : BaseUser
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);
            builder.Property(x=>x.FirstName).HasMaxLength(256).IsRequired();
            builder.Property(x=>x.LastName).HasMaxLength(256).IsRequired();
            builder.Property(x=>x.Email).HasMaxLength(256).IsRequired();
            builder.Property(x => x.DateOfBirth).HasColumnType("date").IsRequired();
            builder.Property(x=>x.Gender).IsRequired();
            builder.Property(x=>x.IdentityId).IsRequired();

        }
    }
}
