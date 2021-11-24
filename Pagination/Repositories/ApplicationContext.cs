using Bogus;
using Microsoft.EntityFrameworkCore;
using Pagination.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pagination.Repositories
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions options): base(options){}

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var ids = 1;
            var stock = new Faker<Product>()
                .RuleFor(m => m.Id, f => ids++)
                .RuleFor(m => m.Name, f => f.Commerce.ProductName())
                .RuleFor(m => m.Category, f => f.Commerce.Categories(1).First())
                .RuleFor(m => m.Price, f => f.Commerce.Price(1).First());

            // generate 1000 items
            modelBuilder
                .Entity<Product>()
                .HasData(stock.GenerateBetween(1000, 1000));
        }
    }
}
