using System;
using System.Threading.Tasks;
using Autofac;
using Sirius.Abstraction.CQRS;

namespace Siruis.Application.Buses
{
    public class QueryBus : IQueryBus
    {
        private readonly ILifetimeScope _lifetimeScope;

        public QueryBus(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public async Task<TResult> Execute<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
            where TResult : IQueryResult
        {
            var resolveHandler = ResolveHandler<TQuery, TResult>(query);
            
            var result = await resolveHandler.Execute(query);

            return result;
        }

        private IQueryHandler<TQuery, TResult> ResolveHandler<TQuery, TResult>(TQuery query)
            where TQuery : IQuery<TResult>
            where TResult : IQueryResult
        {
            var commandHandler = _lifetimeScope.ResolveOptional<IQueryHandler<TQuery, TResult>>();
            if (commandHandler == null)
            {
                throw new InvalidOperationException("Query handler not found");
            }
            return commandHandler;
        }
    }
}