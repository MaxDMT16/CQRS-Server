using System;
using Sirius.Abstraction.CQRS;

namespace Sirius.Abstraction.Contracts.Commands.Order
{
    public class DeleteOrderCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}