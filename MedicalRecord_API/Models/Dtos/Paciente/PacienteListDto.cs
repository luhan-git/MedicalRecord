
namespace MedicalRecord_API.Models.Dtos.Paciente
{
    public class PacienteListDto
    {
        public int Id { get; set; }

        public string Condicion { get; set; } = null!;

        public string PrimerNombre { get; set; } = null!;

        public string APaterno { get; set; } = null!;

        public string TipoDocumento { get; set; } = null!;

        public string NumeroDocumento { get; set; } = null!;

        public string Edad { get; set; } = null!;

        public string Sexo { get; set; } = null!;

        public string? Celular { get; set; }

        public bool? IsAsegurado { get; set; }

        public bool? IsAlergico { get; set; }

        public bool? IsDiabetico { get; set; }
        public bool? IsDelete { get; set; }
    }
}
