using System.Threading.Tasks;
using Sirius.Abstraction.Contracts.Commands.Category;
using Sirius.Database.Context;
using Sirius.Database.Handlers;

namespace Sirius.Domain.Handler.Command.Category
{
    public class CreateCategoryCommandHandler : DatabaseCommandHandlerBase<CreateCategoryCommand>
    {
        public CreateCategoryCommandHandler(ISiriusDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(CreateCategoryCommand context)
        {
            var category = new Database.Entities.Category
            {
                Name = context.Name,
                Area = context.Area
            };

            DbContext.Categories.Add(category);
            await DbContext.SaveChangesAsync();
        }
    }
}