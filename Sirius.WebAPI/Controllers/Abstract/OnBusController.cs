using System.Web.Http;
using Sirius.Abstraction.CQRS;

namespace Sirius.WebAPI.Controllers.Abstract
{
    public class OnBusController : ApiController
    {
        protected OnBusController(IQueryBus queryBus, ICommandBus commandBus)
        {
            QueryBus = queryBus;
            CommandBus = commandBus;
        }

        public IQueryBus QueryBus { get; }
        public ICommandBus CommandBus { get; }
    }
}
