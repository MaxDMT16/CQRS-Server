using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Sirius.Abstraction.Contracts.Commands.Transaction;
using Sirius.Database.Context;
using Sirius.Database.Handlers;

namespace Sirius.Domain.Handler.Command.Transaction
{
    public class DeleteTransactionCommandHandler : DatabaseCommandHandlerBase<DeleteTransactionCommand>
    {
        public DeleteTransactionCommandHandler(ISiriusDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(DeleteTransactionCommand context)
        {
            var transactionToDelete =
                await DbContext.Transactions.FirstOrDefaultAsync(transaction => transaction.Id == context.Id);

            if (transactionToDelete == null)
            {
                throw new InvalidOperationException("Can not find transaction to delete");
            }

            DbContext.Transactions.Remove(transactionToDelete);
            await DbContext.SaveChangesAsync();
        }
    }
}