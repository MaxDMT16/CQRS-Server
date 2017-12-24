using System;
using Sirius.Abstraction.CQRS;

namespace Sirius.Abstraction.Contracts.Commands.Transaction
{
    public class CreateTransactionCommand : ICommand
    {
        public Guid OrderId { get; set; }
        public string Status { get; set; }
    }
}