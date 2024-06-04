using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MedicalRecord_API.Services.Interfaces;

namespace MedicalRecord_API.Services.Implements
{
    public class UtilsService:IUtilsService
    {
         public Task<string>  ConvertirSha256(string input)
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
            return Task.FromResult(Sb.ToString());
        }
    }
}