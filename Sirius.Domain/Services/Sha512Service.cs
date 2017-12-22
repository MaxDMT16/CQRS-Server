using System;
using System.Security.Cryptography;
using System.Text;
using Sirius.Abstraction.Services;

namespace Sirius.Domain.Services
{
    public class Sha512Service : ISha512Service
    {
        public string Calculate(string input)
        {
            using (var provider = new SHA512CryptoServiceProvider())
            {
                var buffer = Encoding.UTF8.GetBytes(input);

                var computeHash = provider.ComputeHash(buffer);

                var base64String = Convert.ToBase64String(computeHash);

                return base64String;
            }
        }
    }
}