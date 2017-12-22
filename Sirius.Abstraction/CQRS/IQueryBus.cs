using System.Threading.Tasks;

namespace Sirius.Abstraction.CQRS
{
    public interface IQueryBus
    {
        Task<TResult> Execute<TQuery, TResult>(TQuery query)
            where TQuery : IQuery<TResult>
            where TResult : IQueryResult;
    }
}