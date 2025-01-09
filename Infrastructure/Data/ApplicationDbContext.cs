using Core.Entities;
using Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    /// <summary>
    /// Handles interaction with the database.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public required DbSet<User> Users { get; set; }
        public required DbSet<Ticket> Tickets { get; set; }
        public required DbSet<Price> Prices { get; set; }
        public required DbSet<Payment> Payments { get; set; }
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            //optionsBuilder.UseSqlServer("Data Source=ASUS\\SQL2014;Initial Catalog=AppParkingSys;Persist Security Info=True;User ID=profit;Password=profit;Trust Server Certificate=True");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new TicketConfiguration());
            builder.ApplyConfiguration(new PriceConfiguration());
            builder.ApplyConfiguration(new PaymentConfiguration());
        }

    }
}
