using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParkingSys_Back.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<Core.Entities.User>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.User> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .UseIdentityColumn();

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder
                .Property(x => x.Email)
                .HasMaxLength(255);
            
            builder
                .Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(20);

            builder
                .Property(x => x.Role)
                .HasMaxLength(20);

            builder
                .ToTable("Users");
        }
    }
}
