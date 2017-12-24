using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sirius.Abstraction.Contracts.Commands.Product;
using Sirius.Database.Context;
using Sirius.Database.Entities;
using Sirius.Database.Handlers;

namespace Sirius.Domain.Handler.Command.Product
{
    public class CreateProductCommandHandler : DatabaseCommandHandlerBase<CreateProductCommand>
    {
        public CreateProductCommandHandler(ISiriusDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(CreateProductCommand context)
        {
            var product = new Database.Entities.Product
            {
                Title = context.Title,
                Prices = context.Prices.Select(price => new Price
                {
                    Id = price.PriceId
                }).ToList(),
                CategoryId = context.CategoryId
            };

            DbContext.Products.Add(product);
            await DbContext.SaveChangesAsync();
        }
    }
}