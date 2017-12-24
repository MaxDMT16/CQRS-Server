using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Sirius.Abstraction.Contracts.Commands.Product;
using Sirius.Database.Context;
using Sirius.Database.Entities;
using Sirius.Database.Handlers;

namespace Sirius.Domain.Handler.Command.Product
{
    public class UpdateProductCommandHandler : DatabaseCommandHandlerBase<UpdateProductCommand>
    {
        public UpdateProductCommandHandler(ISiriusDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(UpdateProductCommand context)
        {
            var productToUpdate = await DbContext.Products.Include(product => product.Prices)
                .FirstOrDefaultAsync(product => product.Id == context.Id);

            if (productToUpdate == null)
            {
                throw new InvalidOperationException("Can not find product to update");
            }

            productToUpdate.Title = context.Title ?? productToUpdate.Title;
            productToUpdate.CategoryId = context.CategotyId ?? productToUpdate.CategoryId;

            UpdateProductPrices(context.Prices, productToUpdate);

            await DbContext.SaveChangesAsync();
        }

        private void UpdateProductPrices(ICollection<UpdateProductCommand.Price> contextPrices, Database.Entities.Product productToUpdate)
        {
            DbContext.RemoveRange(productToUpdate.Prices);

            foreach (var price in contextPrices)
            {
                productToUpdate.Prices.Add(new Price
                {
                    Amount = price.Amount,
                    Color = price.Color,
                    Size = price.Size
                });
            }
        }
    }
}