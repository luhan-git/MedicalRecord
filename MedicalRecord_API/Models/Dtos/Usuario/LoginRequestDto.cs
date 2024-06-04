using System.ComponentModel.DataAnnotations;

namespace MedicalRecord_API.Models.Dtos.Usuario
{
    public class LoginRequestDto
    {
        [Required]
        public string  Correo { get; set; }=null!;
        [Required]
        public string  Password{ get; set; }=null!;
    }
}
