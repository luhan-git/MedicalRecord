namespace MedicalRecord_API.Models.Dtos.Usuario
{
    public class LoginResponseDto
    {
        public UsuarioDto? Usuario { get; set; }
        public string?  Token { get; set; }
    }
}
