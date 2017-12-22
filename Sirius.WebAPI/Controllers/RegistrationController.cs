using System.Threading.Tasks;
using System.Web.Http;
using Sirius.Abstraction.CQRS;
using Sirius.WebAPI.Controllers.Abstract;

namespace Sirius.WebAPI.Controllers
{
    public class RegistrationController : OnBusController
    {
        public RegistrationController(IQueryBus queryBus, ICommandBus commandBus) : base(queryBus, commandBus)
        {
        }

        [HttpPost]
        [Route]
        public async Task RegisterCustomer(CreateCustomerModel model)
    }
}
