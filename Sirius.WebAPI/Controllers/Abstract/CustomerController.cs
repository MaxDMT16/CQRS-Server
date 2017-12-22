using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using Sirius.Abstraction.CQRS;
using Sirius.Abstraction.Services;

namespace Sirius.WebAPI.Controllers.Abstract
{
    public class CustomerController : OnBusController
    {
        private readonly ITokenService _accessTokenService;

        public CustomerController(ITokenService accessTokenService, IQueryBus queryBus, ICommandBus commandBus)
            : base(queryBus, commandBus)
        {
            _accessTokenService = accessTokenService;
        }

        public Guid CustomerId { get; set; }

        public override async Task<HttpResponseMessage> ExecuteAsync(HttpControllerContext controllerContext,
            CancellationToken cancellationToken)
        {
            IEnumerable<string> allTokens;
            if (!controllerContext.Request.Headers.TryGetValues("AccessToken", out allTokens))
            {
                throw new InvalidOperationException("Access token not found");
            }

            var payload = await _accessTokenService.Verify<TokenPayload>(allTokens.First());

            CustomerId = payload.CustomerId;

            return await base.ExecuteAsync(controllerContext, cancellationToken);
        }
    }
}
