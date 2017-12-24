using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Sirius.Abstraction.Contracts.Commands.Order;
using Sirius.Database.Context;
using Sirius.Database.Handlers;

namespace Sirius.Domain.Handler.Command.Order
{
    public class UpdateOrderCommandHandler : DatabaseCommandHandlerBase<UpdateOrderCommand>
    {
        public UpdateOrderCommandHandler(ISiriusDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(UpdateOrderCommand context)
        {
            var orderToUpdate = await DbContext.Orders.FirstOrDefaultAsync(order => order.Id == context.Id);

            if (orderToUpdate == null)
            {
                throw new InvalidOperationException("Can not find order to update");
            }

            orderToUpdate.TotalAmount = context.TotalAmount ?? orderToUpdate.TotalAmount;
            orderToUpdate.CustomerId = context.CustomerId ?? orderToUpdate.CustomerId;
            orderToUpdate.Products = context.Products.Select(product => new Database.Entities.Product
            {
                Id = product.ProductId
            }).ToList();

            await DbContext.SaveChangesAsync();
        }
    }
}