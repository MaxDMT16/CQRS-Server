using System.Threading.Tasks;
using System.Web.Http;
using Sirius.Abstraction.Contracts.Commands;
using Sirius.Abstraction.CQRS;
using Sirius.Abstraction.Services;
using Sirius.WebAPI.Controllers.Abstract;

namespace Sirius.WebAPI.Controllers.Public
{
    [RoutePrefix("api/public/registration")]
    public class RegistrationController : OnBusController
    {
        private readonly ISha512Service _sha512Service;

        public RegistrationController(IQueryBus queryBus, ICommandBus commandBus, ISha512Service sha512Service) : base(queryBus, commandBus)
        {
            _sha512Service = sha512Service;
        }

        [HttpPost]
        [Route]
        public async Task RegisterCustomer(CreateCustomerCommand command)
        {
            command.Password = _sha512Service.Calculate(command.Password);

            await CommandBus.Execute(command);
        }
    }
}
