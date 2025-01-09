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
    public class TicketConfiguration : IEntityTypeConfiguration<Core.Entities.Ticket>
    {
        void IEntityTypeConfiguration<Ticket>.Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder
              .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .UseIdentityColumn();
            
            builder
               .Property(x => x.EntryTime);

            builder
               .Property(x => x.ExitTime);

            builder
                .ToTable("Tickets");
        }
    }
}
