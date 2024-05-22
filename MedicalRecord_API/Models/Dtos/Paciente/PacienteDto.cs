
namespace MedicalRecord_API.Models.Dtos.Paciente
{
    public class PacienteDto
    {
        public int Id { get; set; }

        public string Nombres { get; set; } = null!;

        public string NumeroDocumento { get; set; } = null!;

        public string Edad { get; set; } = null!;

        public string? Celular { get; set; }

        public bool? Asegurado { get; set; }
        public string Condicion { get; set; } = null!;
        public DateTime? FechaActualizacion { get; set; }

    }
}
