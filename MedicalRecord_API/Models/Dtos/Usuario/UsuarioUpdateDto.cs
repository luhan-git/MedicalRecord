using System.ComponentModel.DataAnnotations;

namespace MedicalRecord_API.Models.Dtos.Usuario
{
    public class UsuarioUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public string Correo { get; set; } = null!;
        [Required]
        [StringLength(30)]
        public string Cargo { get; set; } = null!;
        [Required]
        public string? Especialidad { get; set; }
        [Required]
        [StringLength(6)]
        public string? NroColMedico { get; set; }
        [Required]
        public bool? Activo { get; set; }
    }
}
