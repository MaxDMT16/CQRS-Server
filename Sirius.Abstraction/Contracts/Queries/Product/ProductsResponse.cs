using System;
using System.Collections.Generic;
using Sirius.Abstraction.CQRS;

namespace Sirius.Abstraction.Contracts.Queries.Product
{
    public class ProductsResponse : IQueryResult
    {
        public ICollection<Product> Products { get; set; }

        public class Product
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public ICollection<Price> Prices { get; set; }
        }

        public class Price
        {
            public string Size { get; set; }
            public string Color { get; set; }
            public decimal Amount { get; set; }
        }
    }
}