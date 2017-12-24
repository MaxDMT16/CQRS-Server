using System;
using System.Collections.Generic;
using Sirius.Abstraction.CQRS;

namespace Sirius.Abstraction.Contracts.Commands.Product
{
    public class CreateProductCommand : ICommand
    {
        public string Title { get; set; }
        public Guid CategoryId { get; set; }
        public ICollection<Price> Prices { get; set; }

        public class Price
        {
            public Guid PriceId { get; set; }
        }
    }
}