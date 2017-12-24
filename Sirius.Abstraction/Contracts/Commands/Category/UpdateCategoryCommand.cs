using System;
using Sirius.Abstraction.CQRS;

namespace Sirius.Abstraction.Contracts.Commands.Category
{
    public class UpdateCategoryCommand : ICommand
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Area { get; set; }
    }
}