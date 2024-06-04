using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalRecord_API.Services.Interfaces
{
    public interface IUtilsService
    {
         Task<string> ConvertirSha256(string input);
    }
}