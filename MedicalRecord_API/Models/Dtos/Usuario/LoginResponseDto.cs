namespace MedicalRecord_API.Models.Dtos.Usuario
{
    public class LoginResponseDto
    {
        public UsuarioDto? UsuarioDto { get; set; }
        public string?  Token { get; set; }
    }
}
