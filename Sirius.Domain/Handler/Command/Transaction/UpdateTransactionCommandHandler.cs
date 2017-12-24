using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Sirius.Abstraction.Contracts.Commands.Transaction;
using Sirius.Database.Context;
using Sirius.Database.Handlers;

namespace Sirius.Domain.Handler.Command.Transaction
{
    public class UpdateTransactionCommandHandler : DatabaseCommandHandlerBase<UpdateTransactionCommand>
    {
        public UpdateTransactionCommandHandler(ISiriusDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(UpdateTransactionCommand context)
        {
            var transactionToUpdate =
                await DbContext.Transactions.FirstOrDefaultAsync(transaction => transaction.Id == context.Id);

            if (transactionToUpdate == null)
            {
                throw new InvalidOperationException("Can not find transaction to update");
            }

            transactionToUpdate.OrderId = context.OrderId ?? transactionToUpdate.OrderId;
            transactionToUpdate.Status = context.Status ?? transactionToUpdate.Status;

            await DbContext.SaveChangesAsync();
        }
    }
}