using System.Threading.Tasks;
using System.Web.Http;
using Sirius.Abstraction.Contracts.Commands.Product;
using Sirius.Abstraction.Contracts.Queries.Product;
using Sirius.Abstraction.CQRS;
using Sirius.Abstraction.Services;
using Sirius.WebAPI.Controllers.Abstract;

namespace Sirius.WebAPI.Controllers.User
{
    [RoutePrefix("api/product")]
    public class ProductController : CustomerController
    {
        public ProductController(ITokenService accessTokenService, IQueryBus queryBus, ICommandBus commandBus) : base(accessTokenService, queryBus, commandBus)
        {
        }

        [HttpGet]
        [Route]
        public async Task<ProductsResponse> GetAll(ProductsQuery query)
        {
            var productsResponse = await QueryBus.Execute<ProductsQuery, ProductsResponse>(query);
            return productsResponse;
        }

        [HttpPost]
        [Route]
        public async Task CreateProduct(CreateProductCommand command)
        {
            await CommandBus.Execute(command);
        }
    }
}
