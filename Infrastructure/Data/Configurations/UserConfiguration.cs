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
    public class UserConfiguration : IEntityTypeConfiguration<Core.Entities.User>
    {
        void IEntityTypeConfiguration<User>.Configure(EntityTypeBuilder<User> builder)
        {
            builder
               .HasKey(x => x.Id);
         
            builder
                .Property(x => x.Id)
                .UseIdentityColumn();

            builder
                .Property(x => x.Email)
                .HasMaxLength(150);

            builder
                .Property(x => x.PasswordHash)
                .IsRequired()
                .HasMaxLength(255);

            builder
                .Property(x => x.Role)
                .HasMaxLength(20);

            builder
                .ToTable("Users");
        }
    }
}
