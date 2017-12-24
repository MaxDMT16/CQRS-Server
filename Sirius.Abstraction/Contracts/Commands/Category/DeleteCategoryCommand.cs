using System;
using Sirius.Abstraction.CQRS;

namespace Sirius.Abstraction.Contracts.Commands.Category
{
    public class DeleteCategoryCommand : ICommand
    {
        public Guid CategoryId { get; set; }
    }
}