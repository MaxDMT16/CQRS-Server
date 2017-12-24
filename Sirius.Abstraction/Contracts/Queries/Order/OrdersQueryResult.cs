using System.Collections.Generic;
using Sirius.Abstraction.CQRS;

namespace Sirius.Abstraction.Contracts.Queries.Order
{
    public class OrdersQueryResult : IQueryResult
    {
        public ICollection<Order> Orders { get; set; }

        public class Order
        {
            public decimal TotalAmount { get; set; }
            public Customer Customer { get; set; }
            public ICollection<Product> Products { get; set; }
        }

        public class Customer
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public class Product
        {
            public string Title { get; set; }
        }
    }
}