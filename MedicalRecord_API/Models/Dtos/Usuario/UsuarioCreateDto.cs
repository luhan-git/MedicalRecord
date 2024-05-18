using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MedicalRecord_API.Models.Dtos.Usuario
{
    public class UsuarioCreateDto
    {
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public string Correo { get; set; } = null!;
        [Required]
        public string Clave { get; set; } = null!;
        [Required]
        [StringLength(30)]
        public string Cargo { get; set; } = null!;

        public string? Especialidad { get; set; }
        [StringLength(6)]
        public string? NroColMedico { get; set; }
    }
}
