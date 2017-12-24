using System;
using Sirius.Abstraction.CQRS;

namespace Sirius.Abstraction.Contracts.Commands.Product
{
    public class DeleteProductCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}