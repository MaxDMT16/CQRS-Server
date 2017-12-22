using System.Threading.Tasks;
using Sirius.Abstraction.Contracts.Commands;
using Sirius.Database.Context;
using Sirius.Database.Entities;
using Sirius.Database.Handlers;

namespace Sirius.Domain.Handler
{
    public class CreateCustomerCommandHandler : DatbaseCommandHandlerBase<CreateCustomerCommand>
    {
        public CreateCustomerCommandHandler(ISiriusDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(CreateCustomerCommand context)
        {
            var customer = new Customer
            {
                FirstName = context.FirstName,
                LastName = context.LastName,
                Address = new Address
                {
                    Address1 = context.CustomerAddress.Address1,
                    City = context.CustomerAddress.City,
                    Country = context.CustomerAddress.Country,
                    State = context.CustomerAddress.State
                },
                Email = context.Email,
                Password = context.Password,
                Phone = context.Phone
            };

            DbContext.Customers.Add(customer);
        }
    }
}