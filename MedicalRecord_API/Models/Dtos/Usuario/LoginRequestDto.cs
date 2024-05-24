using System.ComponentModel.DataAnnotations;

namespace MedicalRecord_API.Models.Dtos.Usuario
{
    public class LoginRequestDto
    {
        public string  Correo { get; set; }
        public string  Password{ get; set; }
    }
}
