using System.Threading.Tasks;
using System.Web.Http;
using Sirius.Abstraction.Contracts.Commands.Order;
using Sirius.Abstraction.Contracts.Queries.Order;
using Sirius.Abstraction.CQRS;
using Sirius.Abstraction.Services;
using Sirius.WebAPI.Controllers.Abstract;

namespace Sirius.WebAPI.Controllers.User
{
    [RoutePrefix("api/order")]
    public class OrderController : CustomerController
    {
        public OrderController(ITokenService accessTokenService, IQueryBus queryBus, ICommandBus commandBus) : base(accessTokenService, queryBus, commandBus)
        {
        }

        [HttpGet]
        [Route]
        public async Task<OrdersQueryResult> GetAll(OrdersQuery query)
        {
            return await QueryBus.Execute<OrdersQuery, OrdersQueryResult>(query);
        }

        [HttpPost]
        [Route]
        public async Task CreateOrder(CreateOrderCommand command)
        {
            await CommandBus.Execute(command);
        }

        [HttpPut]
        [Route]
        public async Task UpdateOrder(UpdateOrderCommand command)
        {
            await CommandBus.Execute(command);
        }

        [HttpDelete]
        [Route]
        public async Task DeleteOrder(DeleteOrderCommand command)
        {
            await CommandBus.Execute(command);
        }
    }
}
