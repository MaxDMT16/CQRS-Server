using System.Threading.Tasks;

namespace Sirius.Abstraction.CQRS
{
    public interface IQueryHandler<TQuery, TResult>
        where TResult : IQueryResult
        where TQuery : IQuery<TResult>
    {
        Task<TResult> Execute(TQuery query);
    }
}