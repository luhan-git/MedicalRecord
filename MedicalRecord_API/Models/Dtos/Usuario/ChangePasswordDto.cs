using System.ComponentModel.DataAnnotations;

namespace MedicalRecord_API.Models.Dtos.Usuario
{
    public class ChangePasswordDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "Identificador fuera del rango")]
        public int Id { get; set; }
        [Required]
        public string CurrentPassword { get; set; } = null!;
        [Required]
        public string NewPassword { get; set; } = null!;
    }
}
