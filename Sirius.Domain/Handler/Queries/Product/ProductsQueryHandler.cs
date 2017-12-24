using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Sirius.Abstraction.Contracts.Queries.Product;
using Sirius.Database.Context;
using Sirius.Database.Handlers;

namespace Sirius.Domain.Handler.Queries.Product
{
    public class ProductsQueryHandler : DatabaseQueryHandlerBase<ProductsQuery, ProductsResponse>
    {
        public ProductsQueryHandler(ISiriusDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<ProductsResponse> Execute(ProductsQuery query)
        {
            var products = await DbContext.Products.Select(product => new ProductsResponse.Product
            {
                Id = product.Id,
                Title = product.Title,
                Prices = product.Prices.Select(price => new ProductsResponse.Price
                {
                    Amount = price.Amount,
                    Color = price.Color,
                    Size = price.Size
                }).ToList()
            }).ToListAsync();

            if(products == null)
            {
                throw new InvalidOperationException("Can not get products");
            }

            return new ProductsResponse
            {
                Products = products
            };
        }
    }
}