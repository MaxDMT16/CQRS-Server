using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace Sirius.Database.Context
{
    public interface IDbContext
    {
        IDbConnection Connection { get; }

        IEnumerable<TEntity> AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;

        void Dispose();
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        IEnumerable<TEntity> RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        Task<int> SaveChangesAsync();
    }
}