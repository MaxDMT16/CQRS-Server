using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Sirius.Abstraction.Contracts.Commands.Order;
using Sirius.Database.Context;
using Sirius.Database.Handlers;

namespace Sirius.Domain.Handler.Command.Order
{
    public class DeleteOrderCommandHandler : DatabaseCommandHandlerBase<DeleteOrderCommand>
    {
        public DeleteOrderCommandHandler(ISiriusDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(DeleteOrderCommand context)
        {
            var orderToDelete = await DbContext.Orders.FirstOrDefaultAsync(order => order.Id == context.Id);

            if (orderToDelete == null)
            {
                throw new InvalidOperationException("Can not find order to delete");
            }

            DbContext.Orders.Remove(orderToDelete);
            await DbContext.SaveChangesAsync();
        }
    }
}