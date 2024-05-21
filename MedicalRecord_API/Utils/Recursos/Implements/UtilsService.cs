using MedicalRecord_API.Utils.Recursos.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace MedicalRecord_API.Utils.Recursos.Implements
{
    public class UtilsService : IUtilsService
    {
        public async Task<string> ConvertirSha256Async(string input)
        {
            StringBuilder Sb = new();
            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] bytes = hash.ComputeHash(enc.GetBytes(input));
                foreach (byte b in bytes)
                {
                    Sb.Append(b.ToString("x2"));
                }
            }
            return Sb.ToString();
        }
    }
}
