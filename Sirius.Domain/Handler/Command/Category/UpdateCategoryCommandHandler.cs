using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Sirius.Abstraction.Contracts.Commands.Category;
using Sirius.Database.Context;
using Sirius.Database.Handlers;

namespace Sirius.Domain.Handler.Command.Category
{
    public class UpdateCategoryCommandHandler : DatabaseCommandHandlerBase<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandHandler(ISiriusDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(UpdateCategoryCommand context)
        {
            var categoryToUpdate = await DbContext.Categories.FirstOrDefaultAsync(
                category => category.Id == context.CategoryId);

            if (categoryToUpdate == null)
            {
                throw new InvalidOperationException("Can not update category");
            }

            categoryToUpdate.Name = context.Name ?? categoryToUpdate.Name;
            categoryToUpdate.Area = context.Area ?? categoryToUpdate.Area;

            await DbContext.SaveChangesAsync();
        }
    }
}