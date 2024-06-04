using System.ComponentModel.DataAnnotations;

namespace MedicalRecord_API.Models.Dtos.Usuario
{
    public class LoginRequestDto
    {
        [Required]
        public string  Correo { get; set; }
        [Required]
        public string  Password{ get; set; }
    }
}
