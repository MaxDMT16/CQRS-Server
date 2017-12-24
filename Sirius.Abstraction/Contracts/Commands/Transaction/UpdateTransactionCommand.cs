using System;
using Sirius.Abstraction.CQRS;

namespace Sirius.Abstraction.Contracts.Commands.Transaction
{
    public class UpdateTransactionCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public Guid? OrderId { get; set; }
    }
}