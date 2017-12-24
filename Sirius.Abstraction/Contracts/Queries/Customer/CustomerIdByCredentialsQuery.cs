using Sirius.Abstraction.CQRS;

namespace Sirius.Abstraction.Contracts.Queries.Customer
{
    public class CustomerIdByCredentialsQuery : IQuery<CustomerIdResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}