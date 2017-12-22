using System.Data.Entity;
using Sirius.Database.Entities;

namespace Sirius.Database.Context
{
    public interface ISiriusDbContext : IDbContext
    {
        DbSet<Customer> Customers { get; }
        DbSet<Order> Orders { get; }
        DbSet<Product> Products { get; }
        DbSet<Price> Price { get; }
        DbSet<Category> Categories { get; }
        DbSet<Transaction> Transactions { get; }
    }
}