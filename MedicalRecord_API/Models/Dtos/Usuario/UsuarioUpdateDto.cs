using System.ComponentModel.DataAnnotations;

namespace MedicalRecord_API.Models.Dtos.Usuario
{
    public class UsuarioUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; } = null!;
        [Required]
        public string Correo { get; set; } = null!;
        [Required]
        public string Clave { get; set; } = null!;
        [Required]
        public string Cargo { get; set; } = null!;
        [Required]
        public string? Especialidad { get; set; }
        [Required]
        public string? NroColMedico { get; set; }
        [Required]
        public bool? Activo { get; set; }
    }
}
