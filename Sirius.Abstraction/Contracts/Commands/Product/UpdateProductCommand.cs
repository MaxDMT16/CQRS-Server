using System;
using System.Collections.Generic;
using Sirius.Abstraction.CQRS;

namespace Sirius.Abstraction.Contracts.Commands.Product
{
    public class UpdateProductCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid? CategotyId { get; set; }
        public ICollection<Price> Prices { get; set; }

        public class Price
        {
            public string Color { get; set; }
            public string Size { get; set; }
            public decimal Amount { get; set; }
        }
    }
}