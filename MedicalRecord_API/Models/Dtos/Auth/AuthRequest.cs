using System.ComponentModel.DataAnnotations;

namespace MedicalRecord_API.Models.Dtos.Auth
{
    public class AuthRequest
    {
        [Required]
        public string Correo { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}