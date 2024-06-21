namespace MedicalRecord_API.Models.Dtos.Paciente
{
    public class AntecedenteDto
    {
        public int Id { get; set; }

        public int IdPaciente { get; set; }

        public string? AntecedentesClinicos { get; set; }

        public string? AntecedentesFamiliares { get; set; }

        public string PresionArterial { get; set; } = null!;

        public string? CampoVisual { get; set; }

        public int? IdDiabete { get; set; }
        public string? Diabetes { get; set; }
        public bool? IsDelete { get; set; }
        public virtual ICollection<DetalleAlergiaDto> Detallealergia { get; set; } = [];

    }
}
