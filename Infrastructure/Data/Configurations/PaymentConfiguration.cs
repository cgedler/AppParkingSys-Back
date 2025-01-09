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
    public class PaymentConfiguration : IEntityTypeConfiguration<Core.Entities.Payment>
    {
        void IEntityTypeConfiguration<Payment>.Configure(EntityTypeBuilder<Payment> builder)
        {
            builder
              .HasKey(x => x.Id);

            builder
               .Property(x => x.Amount)
               .HasColumnType("decimal(18,2)");

            builder
               .Property(x => x.PaymentDate);

            builder
                .ToTable("Payments");
        }
    }
}
