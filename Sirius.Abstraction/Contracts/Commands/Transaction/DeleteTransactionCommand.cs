using System;
using Sirius.Abstraction.CQRS;

namespace Sirius.Abstraction.Contracts.Commands.Transaction
{
    public class DeleteTransactionCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}