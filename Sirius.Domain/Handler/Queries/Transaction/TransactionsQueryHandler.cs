using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Sirius.Abstraction.Contracts.Queries.Transaction;
using Sirius.Database.Context;
using Sirius.Database.Handlers;

namespace Sirius.Domain.Handler.Queries.Transaction
{
    public class TransactionsQueryHandler : DatabaseQueryHandlerBase<TransactionsQuery, TransactionsQueryResult>
    {
        public TransactionsQueryHandler(ISiriusDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<TransactionsQueryResult> Execute(TransactionsQuery query)
        {
            var transactions = await DbContext.Transactions.Select(transaction => new TransactionsQueryResult.Transaction
            {
                OrderId = transaction.OrderId,
                Status = transaction.Status
            }).ToListAsync();

            if (transactions == null)
            {
                throw new InvalidOperationException("Can not get transactions");
            }

            return new TransactionsQueryResult
            {
                Transactions = transactions
            };
        }
    }
}