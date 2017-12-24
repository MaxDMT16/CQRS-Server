using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Sirius.Abstraction.Contracts.Queries.Category;
using Sirius.Database.Context;
using Sirius.Database.Handlers;

namespace Sirius.Domain.Handler.Queries.Category
{
    public class CategoriesQueryHandler : DatabaseQueryHandlerBase<CategoriesQuery, CategoriesResponse>
    {
        public CategoriesQueryHandler(ISiriusDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<CategoriesResponse> Execute(CategoriesQuery query)
        {
            var categories = await DbContext.Categories.Select(category => new CategoriesResponse.Category
            {
                Id = category.Id,
                Area = category.Area,
                Name = category.Name
            }).ToListAsync();

            if (categories == null)
            {
                throw new InvalidOperationException("Categories not found");
            }

            return new CategoriesResponse
            {
                Categories = categories
            };
        }
    }
}