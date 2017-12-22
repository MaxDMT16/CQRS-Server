using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sirius.Database.Entities
{
    public class Price : EntityBase
    {
        public decimal Amount { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }

        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}