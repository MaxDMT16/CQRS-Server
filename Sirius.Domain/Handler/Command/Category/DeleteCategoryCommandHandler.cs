using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Sirius.Abstraction.Contracts.Commands.Category;
using Sirius.Database.Context;
using Sirius.Database.Handlers;

namespace Sirius.Domain.Handler.Command.Category
{
    public class DeleteCategoryCommandHandler : DatabaseCommandHandlerBase<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandHandler(ISiriusDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(DeleteCategoryCommand context)
        {
            var categoryToDelete =
                await DbContext.Categories.FirstOrDefaultAsync(category => category.Id == context.CategoryId);
            if (categoryToDelete == null)
            {
                throw new InvalidOperationException("Category to delete not found");
            }
            DbContext.Categories.Remove(categoryToDelete);
            await DbContext.SaveChangesAsync();
        }
    }
}