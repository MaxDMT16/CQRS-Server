using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Sirius.Abstraction.Contracts.Commands.Product;
using Sirius.Database.Context;
using Sirius.Database.Handlers;

namespace Sirius.Domain.Handler.Command.Product
{
    public class DeleteProductCommandHandler : DatabaseCommandHandlerBase<DeleteProductCommand>
    {
        public DeleteProductCommandHandler(ISiriusDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(DeleteProductCommand context)
        {
            var productToDelete = await DbContext.Products.FirstOrDefaultAsync(product => product.Id == context.Id);

            if (productToDelete == null)
            {
                throw new InvalidOperationException("Can not find product to delete");
            }

            DbContext.Products.Remove(productToDelete);

            await DbContext.SaveChangesAsync();
        }
    }
}