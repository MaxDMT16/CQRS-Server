using System.Threading.Tasks;
using Sirius.Abstraction.Contracts.Commands;
using Sirius.Database.Context;
using Sirius.Database.Entities;
using Sirius.Database.Handlers;

namespace Sirius.Domain.Handler.Command
{
    public class CreateCustomerCommandHandler : DatabaseCommandHandlerBase<CreateCustomerCommand>
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
                    Address1 = context.Address.Address1,
                    City = context.Address.City,
                    Country = context.Address.Country,
                    State = context.Address.State
                },
                Email = context.Email,
                Password = context.Password,
                Phone = context.Phone
            };

            DbContext.Customers.Add(customer);
            await DbContext.SaveChangesAsync();
        }
    }
}