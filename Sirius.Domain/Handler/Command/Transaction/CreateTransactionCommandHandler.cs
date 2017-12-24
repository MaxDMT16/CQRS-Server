using System.Threading.Tasks;
using Sirius.Abstraction.Contracts.Commands.Transaction;
using Sirius.Database.Context;
using Sirius.Database.Handlers;

namespace Sirius.Domain.Handler.Command.Transaction
{
    public class CreateTransactionCommandHandler : DatabaseCommandHandlerBase<CreateTransactionCommand>
    {
        public CreateTransactionCommandHandler(ISiriusDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(CreateTransactionCommand context)
        {
            var transaction = new Database.Entities.Transaction
            {
                OrderId = context.OrderId,
                Status = context.Status
            };

            DbContext.Transactions.Add(transaction);
            await DbContext.SaveChangesAsync();
        }
    }
}