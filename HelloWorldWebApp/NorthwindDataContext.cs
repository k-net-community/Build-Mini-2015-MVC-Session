using HelloWorldWebApp.Models;
using Microsoft.Data.Entity;
using Microsoft.Framework.ConfigurationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWebApp
{
    public class NorthwindDataContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new Configuration()
                   .AddJsonFile("config.json")
                   .AddEnvironmentVariables();

            optionsBuilder.UseSqlServer(configuration["Data:DefaultConnection:ConnectionString"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForSqlServer();
            modelBuilder.Entity<Customer>(b =>
            {
                b.ForSqlServer().Table("Customers");
                b.Key(c => c.CustomerID);
            });
        }
    }
}
