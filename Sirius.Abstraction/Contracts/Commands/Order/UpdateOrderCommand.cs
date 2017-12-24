using System;
using System.Collections.Generic;
using Sirius.Abstraction.CQRS;

namespace Sirius.Abstraction.Contracts.Commands.Order
{
    public class UpdateOrderCommand : ICommand
    {
        public Guid Id { get; set; }
        public decimal? TotalAmount { get; set; }
        public ICollection<Product> Products { get; set; }
        public Guid? CustomerId { get; set; }

        public class Product
        {
            public Guid ProductId { get; set; }
        }
    }
}