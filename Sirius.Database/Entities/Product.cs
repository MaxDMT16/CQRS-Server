using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sirius.Database.Entities
{
    public class Product : EntityBase
    {
        public string Title { get; set; }
        public ICollection<Price> Prices { get; set; }

        [ForeignKey(nameof(Category))]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}