using MedicalRecord_API.Models.Dtos.Auth;

namespace MedicalRecord_API.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> GenerateToken(int id, string rol);
        Task<AuthResponse> RetunrAuth(AuthRequest auth);
        Task<bool> IsUserUnique(string correo);

    }
}