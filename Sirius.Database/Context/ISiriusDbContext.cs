using System.Data.Entity;
using Sirius.Database.Entities;

namespace Sirius.Database.Context
{
    public interface ISiriusDbContext : IDbContext
    {
        IDbSet<Customer> Customers { get; }
        IDbSet<Order> Orders { get; }
        IDbSet<Product> Products { get; }
        IDbSet<Price> Price { get; }
        IDbSet<Category> Categories { get; }
        IDbSet<Transaction> Transactions { get; }
    }
}