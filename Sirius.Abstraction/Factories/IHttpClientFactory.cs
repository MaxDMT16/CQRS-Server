using System.Net.Http;

namespace Sirius.Abstraction.Factories
{
    public interface IHttpClientFactory
    {
        HttpClient Create();
    }
}