using Sirius.Abstraction.CQRS;

namespace Sirius.Abstraction.Contracts.Commands.Category
{
    public class CreateCategoryCommand : ICommand
    {
        public string Name { get; set; }
        public string Area { get; set; }
    }
}