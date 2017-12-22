using System.ComponentModel.DataAnnotations.Schema;

namespace Sirius.Database.Entities
{
    [ComplexType]
    public class Address
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Address1 { get; set; }
    }
}