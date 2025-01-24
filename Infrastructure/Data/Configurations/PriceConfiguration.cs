using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Configurations
{
    public class PriceConfiguration : IEntityTypeConfiguration<Core.Entities.Price>
    {
        void IEntityTypeConfiguration<Price>.Configure(EntityTypeBuilder<Price> builder)
        {
            builder
              .HasKey(x => x.Id);
            builder
                .Property(x => x.Id)
                .UseIdentityColumn();
            builder
               .Property(x => x.Amount)
               .HasColumnType("decimal(18,2)");
            builder
                .ToTable("Prices");
        }
    }
}
