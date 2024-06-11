namespace MedicalRecord_API.Models.Dtos.Usuario
{
    public class PerfilDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Correo { get; set; } = null!;
        public string Cargo { get; set; } = null!;

        public string? Especialidad { get; set; }

        public string? NroColMedico { get; set; }

        public string Rol { get; set; } = null!;

        public bool? Activo { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public DateTime? UltimaSesion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
    }
}