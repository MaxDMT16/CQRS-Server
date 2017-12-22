using System.Net.Http;
using Sirius.Abstraction.Factories;

namespace Siruis.Application.Factories
{
    public class HttpClientFactory : IHttpClientFactory
    {
        public HttpClient Create()
        {
            return new HttpClient();
        }
    }
}