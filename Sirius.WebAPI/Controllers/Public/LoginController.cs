using System.Threading.Tasks;
using System.Web.Http;
using Sirius.Abstraction.Contracts.Queries.Customer;
using Sirius.Abstraction.CQRS;
using Sirius.Abstraction.Services;
using Sirius.WebAPI.Controllers.Abstract;
using Sirius.WebAPI.Controllers.Public.Models;
using Siruis.Application.Buses;

namespace Sirius.WebAPI.Controllers.Public
{
    [RoutePrefix("api/public")]
    public class LoginController : OnBusController
    {
        private readonly ITokenService _tokenService;
        private readonly ISha512Service _sha512Service;

        public LoginController(IQueryBus queryBus, ICommandBus commandBus,
            ITokenService tokenService,
            ISha512Service sha512Service)
            : base(queryBus, commandBus)
        {
            _tokenService = tokenService;
            _sha512Service = sha512Service;
        }

        [HttpPost]
        [Route("login")]
        public async Task<LoginResponseModel> Login(LoginRequestModel model)
        {
            var customerIdByCredentialsQuery = new CustomerIdByCredentialsQuery
            {
                Email = model.Email,
                Password = _sha512Service.Calculate(model.Password)
            };

            var customerIdResponse =
                await QueryBus.Execute<CustomerIdByCredentialsQuery, CustomerIdResponse>(customerIdByCredentialsQuery);

            var token = _tokenService.Create(new TokenPayload
            {
                CustomerId = customerIdResponse.Id
            });

            return new LoginResponseModel
            {
                Token = token
            };
        }

    }
}
