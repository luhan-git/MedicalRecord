using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalRecord_API.Models.Dtos.Auth;

namespace MedicalRecord_API.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse>RetunrAuth(AuthRequest auth);
        Task<bool>IsUserUnique(string correo);

    }
}