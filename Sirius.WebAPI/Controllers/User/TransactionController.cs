using System.Threading.Tasks;
using System.Web.Http;
using Sirius.Abstraction.Contracts.Commands.Transaction;
using Sirius.Abstraction.Contracts.Queries.Transaction;
using Sirius.Abstraction.CQRS;
using Sirius.Abstraction.Services;
using Sirius.WebAPI.Controllers.Abstract;

namespace Sirius.WebAPI.Controllers.User
{
    [RoutePrefix("api/transaction")]
    public class TransactionController : CustomerController
    {
        public TransactionController(ITokenService accessTokenService, IQueryBus queryBus, ICommandBus commandBus) : base(accessTokenService, queryBus, commandBus)
        {
        }

        [HttpGet]
        [Route]
        public async Task<TransactionsQueryResult> GetAll(TransactionsQuery query)
        {
            return await QueryBus.Execute<TransactionsQuery, TransactionsQueryResult>(query);
        }

        [HttpPost]
        [Route]
        public async Task CreateTransaction(CreateTransactionCommand command)
        {
            await CommandBus.Execute(command);
        }

        [HttpPut]
        [Route]
        public async Task UpdateTransaction(UpdateTransactionCommand command)
        {
            await CommandBus.Execute(command);
        }

        [HttpDelete]
        [Route]
        public async Task DeleteTransaction(DeleteTransactionCommand command)
        {
            await CommandBus.Execute(command);
        }
    }
}
