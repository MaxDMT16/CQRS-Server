using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using Sirius.Database.Entities;

namespace Sirius.Database.Context
{
    public class SiriusDbContext : DbContext, ISiriusDbContext
    {
        public DbSet<Customer> Customers { get; }
        public DbSet<Order> Orders { get; }
        public DbSet<Product> Products { get; }
        public DbSet<Price> Price { get; }
        public DbSet<Category> Categories { get; }
        public DbSet<Transaction> Transactions { get; }

        public IDbConnection Connection => Database.Connection;

        public IEnumerable<TEntity> AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            return Set<TEntity>().AddRange(entities);
        }

        public IEnumerable<TEntity> RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            return Set<TEntity>().RemoveRange(entities);
        }


    }
}