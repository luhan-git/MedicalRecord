namespace MedicalRecord_API.Models.Dtos.Usuario
{
    public class UsuarioDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Correo { get; set; } = null!;

        public string Rol { get; set; } = null!;

        public bool? Activo { get; set; }

        public DateTime? UltimaSesion { get; set; }

    }
}
