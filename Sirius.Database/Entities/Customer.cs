using System.Collections.Generic;

namespace Sirius.Database.Entities
{
    public class Customer : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }

        public string Token { get; set; }
        
        public Address Address { get; set; } = new Address();
        public ICollection<Order> Orders { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}