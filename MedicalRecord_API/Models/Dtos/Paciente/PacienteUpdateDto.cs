using System.ComponentModel.DataAnnotations;

namespace MedicalRecord_API.Models.Dtos.Paciente
{
    public class PacienteUpdateDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "Identificador fuera del rango")]
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string? Direccion { get; set; }

        public string? Telefono { get; set; }

        public string? Email { get; set; }

        public string? Sexo { get; set; }

        public string? FechaNacimiento { get; set; }

        public string? Ocupacion { get; set; }

        public string? CiaSeguro { get; set; }

        public string? Cie { get; set; }

        public string? Observaciones { get; set; }
    }
}
