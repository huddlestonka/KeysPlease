using System;
using System.Security.Cryptography;

namespace JWTAutomater
{
    public class GenerateMyKeysPlease
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**************************************************************");
            Console.WriteLine("******************Welcome to JWTAutomater*********************");
            Console.WriteLine("**************************************************************");
            Console.WriteLine("--------------------------------------------------------------");

            var keyCreator = new GenerateMyKeysPlease();

            Console.WriteLine("************************AES128 Key****************************");
            // AES128 Key
            var aesKey = keyCreator.GetKeyAes128Key();
            Console.WriteLine(aesKey);
            Console.WriteLine("**************************************************************");
            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("************************HmacSha256 Key************************");
            // HmacSha256 Key
            var hmacSha = keyCreator.GetHmacSha256Key();
            Console.WriteLine(hmacSha);
            Console.WriteLine("**************************************************************");
            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("************************Bearer Token**************************");
            // bearer token
            var bearer = keyCreator.GetBearerToken();
            Console.WriteLine(bearer);
            Console.WriteLine("**************************************************************");
            Console.WriteLine("-------------------------E N J O Y---------------------------");

            // TODO - Let's pipe out these values to file for easy copy/paste
        }

        // Generate an AES128 Key:
        private string GetKeyAes128Key()
        {
            byte[] bytes = new byte[16];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }

        // Generate an HmacSha256 key with the following: 
		private string GetHmacSha256Key()
        {
            var hmac = new HMACSHA256();
            return Convert.ToBase64String(hmac.Key);
        }

        // You will also need to generate a bearer token to share with the client: 
        private string GetBearerToken()
        {
            byte[] bytes = new byte[64];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes).Replace("+", "-").Replace("/", "_");
        }
    }
}
