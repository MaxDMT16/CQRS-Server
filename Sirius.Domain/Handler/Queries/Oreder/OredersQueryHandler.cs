using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Sirius.Abstraction.Contracts.Queries.Order;
using Sirius.Database.Context;
using Sirius.Database.Handlers;

namespace Sirius.Domain.Handler.Queries.Oreder
{
    public class OredersQueryHandler : DatabaseQueryHandlerBase<OrdersQuery, OrdersQueryResult>
    {
        public OredersQueryHandler(ISiriusDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<OrdersQueryResult> Execute(OrdersQuery query)
        {
            var orders = await DbContext.Orders.Select(
                order => new OrdersQueryResult.Order
                {
                    TotalAmount = order.TotalAmount,
                    Customer = new OrdersQueryResult.Customer
                    {
                        LastName = order.Customer.LastName,
                        FirstName = order.Customer.FirstName
                    },
                    Products = order.Products.Select(product => new OrdersQueryResult.Product
                    {
                        Title = product.Title
                    }).ToList()
                }).ToListAsync();

            if (orders == null)
            {
                throw new InvalidOperationException("Can not get orders");
            }

            return new OrdersQueryResult
            {
                Orders = orders
            };
        }
    }
}