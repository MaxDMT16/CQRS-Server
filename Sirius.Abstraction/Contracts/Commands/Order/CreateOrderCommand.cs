using System;
using System.Collections.Generic;
using Sirius.Abstraction.CQRS;

namespace Sirius.Abstraction.Contracts.Commands.Order
{
    public class CreateOrderCommand : ICommand
    {
        public decimal TotalAmount { get; set; }
        public Guid CustomerId { get; set; }
        public ICollection<Guid> ProductIds { get; set; }
    }
}