using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Sirius.Abstraction.Contracts.Queries.Customer;
using Sirius.Database.Context;
using Sirius.Database.Handlers;

namespace Sirius.Domain.Handler.Queries.Customer
{
    public class CustomerIdByCredentialQueryHandler : DatabaseQueryHandlerBase<CustomerIdByCredentialsQuery, CustomerIdResponse>
    {
        public CustomerIdByCredentialQueryHandler(ISiriusDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<CustomerIdResponse> Execute(CustomerIdByCredentialsQuery query)
        {
            var customer =
                await DbContext.Customers.FirstOrDefaultAsync(
                    c => c.Email == query.Email && c.Password == query.Password);

            if (customer == null)
            {
                throw new InvalidOperationException("Customer by credentials not found");
            }

            return new CustomerIdResponse
            {
                Id = customer.Id
            };
        }
    }
}