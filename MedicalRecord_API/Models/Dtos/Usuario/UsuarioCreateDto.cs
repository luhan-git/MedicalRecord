using System.ComponentModel.DataAnnotations;

namespace MedicalRecord_API.Models.Dtos.Usuario
{
    public class UsuarioCreateDto
    {
        public string Nombre { get; set; } = null!;

        public string Correo { get; set; } = null!;

        public string Clave { get; set; } = null!;

        public string Cargo { get; set; } = null!;

        public string? Especialidad { get; set; }

        public string? Rol { get; set; }
    }
}
