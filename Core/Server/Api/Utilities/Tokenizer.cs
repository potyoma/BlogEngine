using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;

namespace BlogEngineApi.Utilities
{
    public static class Tokenizer
    {
        private static readonly byte[] salt = 
            Encoding.Unicode.GetBytes(Startup.StaticConfig.GetSection("Salt").ToString());
        private const int iterations = 2000;

        public static async Task<string> Create(string id, string email)
        {
            // Get secure array bytes.
            byte[] secureArray = await Encrypt(id, email);

            // Convert in an URL safe string.
            string urlToken = WebEncoders.Base64UrlEncode(secureArray);

            return urlToken;
        }

        private static async Task<byte[]> Encrypt(string id, string email)
        {
            byte[] encryptedBytes;
            byte[] plainBytes = Encoding.Unicode.GetBytes(id);
            var aes = Aes.Create();
            var pbkdf2 = new Rfc2898DeriveBytes(
                email, salt, iterations);
            aes.Key = pbkdf2.GetBytes(32);
            aes.IV = pbkdf2.GetBytes(16);

            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(
                    ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    await cs.WriteAsync(plainBytes, 0, plainBytes.Length);
                }

                encryptedBytes = ms.ToArray();
            }

            return encryptedBytes;
        }
    }
}