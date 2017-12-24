using System.Threading.Tasks;
using System.Web.Http;
using Sirius.Abstraction.Contracts.Commands.Category;
using Sirius.Abstraction.Contracts.Queries.Category;
using Sirius.Abstraction.CQRS;
using Sirius.Abstraction.Services;
using Sirius.WebAPI.Controllers.Abstract;

namespace Sirius.WebAPI.Controllers.User
{
    [RoutePrefix("api/category")]
    public class CategoryController : CustomerController
    {
        public CategoryController(ITokenService accessTokenService, IQueryBus queryBus, ICommandBus commandBus) : base(accessTokenService, queryBus, commandBus)
        {
        }

        [HttpGet]
        [Route]
        public async Task<CategoriesResponse> GetAll()
        {
            var categoriesQuery = new CategoriesQuery();
            var categoriesResponse = await QueryBus.Execute<CategoriesQuery, CategoriesResponse>(categoriesQuery);
            return categoriesResponse;
        }

        [HttpPost]
        [Route]
        public async Task CreateCategory(CreateCategoryCommand command)
        {
            await CommandBus.Execute(command);
        }

        [HttpPut]
        [Route]
        public async Task UpdateCategory(UpdateCategoryCommand command)
        {
            await CommandBus.Execute(command);
        }

        [HttpDelete]
        [Route]
        public async Task DeleteCategory(DeleteCategoryCommand command)
        {
            await CommandBus.Execute(command);
        }
    }
}
