using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sirius.Database.Entities
{
    public class Transaction : EntityBase
    {
        public string Status { get; set; }

        [ForeignKey(nameof(Order))]
        public Guid OrderId { get; set; }

        public Order Order { get; set; }
    }
}