using System;
using System.Threading.Tasks;
using Jose;
using Sirius.Abstraction.Services;
using Sirius.Domain.Configurations;

namespace Sirius.Domain.Services
{
    public class TokenService : ITokenService
    {
        private readonly TokenConfiguration _configuration;

        public TokenService(TokenConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Create<TPayload>(TPayload payload, string key)
            where TPayload : TokenPayload
        {
            var keyBytes = Convert.FromBase64String(key);

            var token = JWT.Encode(payload, keyBytes, JwsAlgorithm.HS512);

            return token;
        }

        public async Task<TPayload> Verify<TPayload>(string accessToken) where TPayload : TokenPayload
        {
            try
            {
                var payload = JWT.Payload<TPayload>(accessToken);
                
                var keyBytes = Convert.FromBase64String(_configuration.Key);

                var decode = JWT.Decode<TPayload>(accessToken, keyBytes);

                return decode;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Can not verify token");
            }
        }
    }
}