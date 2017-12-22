using System.Threading.Tasks;

namespace Sirius.Abstraction.Services
{
    public interface ITokenService
    {
        string Create<TPayload>(TPayload payload, string key)
            where TPayload : TokenPayload;

        Task<TPayload> Verify<TPayload>(string accessToken)
            where TPayload : TokenPayload;
    }
}