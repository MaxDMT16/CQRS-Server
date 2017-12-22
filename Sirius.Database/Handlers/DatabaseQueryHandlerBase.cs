using System.Threading.Tasks;
using Sirius.Abstraction.CQRS;
using Sirius.Database.Context;

namespace Sirius.Database.Handlers
{
    public abstract class DatabaseQueryHandlerBase<TQuery, TResponse> : IQueryHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse> where TResponse : IQueryResult
    {
        protected readonly ISiriusDbContext DbContext;

        protected DatabaseQueryHandlerBase(ISiriusDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public abstract Task<TResponse> Execute(TQuery query);
    }
}