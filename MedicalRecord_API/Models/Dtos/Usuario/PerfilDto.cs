namespace MedicalRecord_API.Models.Dtos.Usuario
{
    public class PerfilDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Correo { get; set; } = null!;

        public string Cargo { get; set; } = null!;

        public string? Especialidad { get; set; }

        public string? Rol { get; set; }

        public bool? IsActivo { get; set; }

    }
}