using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using Sirius.Database.Entities;

namespace Sirius.Database.Context
{
    public class SiriusDbContext : DbContext, ISiriusDbContext
    {
        public SiriusDbContext()
        {
        }

        public SiriusDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<Order> Orders { get; set; }
        public IDbSet<Product> Products { get; set; }
        public IDbSet<Price> Price { get; set; }
        public IDbSet<Category> Categories { get; set; }
        public IDbSet<Transaction> Transactions { get; set; }

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