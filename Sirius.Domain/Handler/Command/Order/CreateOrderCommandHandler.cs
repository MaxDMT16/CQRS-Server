using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Sirius.Abstraction.Contracts.Commands.Order;
using Sirius.Database.Context;
using Sirius.Database.Handlers;

namespace Sirius.Domain.Handler.Command.Order
{
    public class CreateOrderCommandHandler : DatabaseCommandHandlerBase<CreateOrderCommand>
    {
        public CreateOrderCommandHandler(ISiriusDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(CreateOrderCommand context)
        {
            var orderedProducts = await DbContext.Products.Where(product => context.ProductIds.Contains(product.Id))
                .ToListAsync();

            var order = new Database.Entities.Order
            {
                TotalAmount = context.TotalAmount,
                CustomerId = context.CustomerId,
                Products = orderedProducts
            };

            DbContext.Orders.Add(order);
            await DbContext.SaveChangesAsync();
        }
    }
}