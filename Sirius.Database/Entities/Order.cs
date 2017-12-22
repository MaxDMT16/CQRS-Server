using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sirius.Database.Entities
{
    public class Order : EntityBase
    {
        public decimal TotalAmount { get; set; }

        [ForeignKey(nameof(Customer))]
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}