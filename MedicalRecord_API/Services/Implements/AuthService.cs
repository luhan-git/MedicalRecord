//using MedicalRecord_API.Models;
//using MedicalRecord_API.Models.Dtos.Auth;
//using MedicalRecord_API.Repository.Interfaces;
//using MedicalRecord_API.Services.Interfaces;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//namespace MedicalRecord_API.Services.Implements
//{
//    public class AuthService : IAuthService
//    {
//        private readonly IGenericRepository<Usuario> _repo;
//        private readonly IUtilsService _utilsService;
//        private readonly string? _secretkey;
//        public AuthService(IGenericRepository<Usuario> repo, IConfiguration configuration, IUtilsService utilsService)
//        {
//            _repo = repo;
//            _utilsService = utilsService;
//            _secretkey = configuration.GetValue<string>("ApiSettings:Secret");
//        }
//        public async Task<bool> IsUserUnique(string correo)
//        {
//            Usuario usuario = await _repo.GetAsync(u => string.Equals(u.Correo, correo));
//            bool band = usuario == null;
//            return band;
//        }

//        public Task<string> GenerateToken(int id, string rol)
//        {
//            var tokenHandler = new JwtSecurityTokenHandler();
//            var key = Encoding.UTF8.GetBytes(_secretkey);
//            var tokenDescriptor = new SecurityTokenDescriptor
//            {
//                Subject = new ClaimsIdentity(
//                [
//                    new(ClaimTypes.Name,id.ToString()),
//                    new(ClaimTypes.Role,rol),
//                ]),
//                Expires = DateTime.UtcNow.AddMinutes(5),
//                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
//            };
//            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);
//            var token = tokenHandler.WriteToken(tokenConfig);
//            return Task.FromResult(token);
//        }
//        public async Task<AuthResponse> RetunrAuth(AuthRequest auth)
//        {
//            if (_secretkey == null) return new();
//            string password = await _utilsService.ConvertirSha256(auth.Password);
//            Usuario usuario = await _repo.GetAsync(u => string.Equals(u.Correo, auth.Correo)
//                                                && string.Equals(u.Clave, password));
//            if (usuario == null)
//                return new();
//            string token = await GenerateToken(usuario.Id, usuario.Rol);
//            AuthResponse response = new()
//            {
//                Token = token,
//                IsSuccess = true,
//                Name = usuario.Nombre,
//                Msg = "OK",
//            };
//            return response;
//        }
//    }
//}