using System.Collections.Generic;

namespace Sirius.Database.Entities
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
        public string Area { get; set; }
    }
}