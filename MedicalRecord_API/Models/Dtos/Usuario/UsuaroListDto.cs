namespace MedicalRecord_API.Models.Dtos.Usuario
{
    public class UsuarioListDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Correo { get; set; } = null!;
        public string? Rol { get; set; }

        public bool? IsActivo { get; set; }

        public DateTime? FechaRegistro { get; set; }
    }
}
