using Sirius.Abstraction.CQRS;

namespace Sirius.Abstraction.Contracts.Commands
{
    public class CreateCustomerCommand : ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }

        public Address CustomerAddress { get; set; }

        public class Address
        {
            public string Country { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Address1 { get; set; }
        }
    }
}