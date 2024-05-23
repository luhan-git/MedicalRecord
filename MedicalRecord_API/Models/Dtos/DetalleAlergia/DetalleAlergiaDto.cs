using MedicalRecord_API.Models.Dtos.Alergia;
using MedicalRecord_API.Models.Dtos.Paciente;

namespace MedicalRecord_API.Models.Dtos.DetalleAlergia
{
    public class DetalleAlergiaDto
    {
        public int Id { get; set; }

        public int IdAlergia { get; set; }

        public int IdPaciente { get; set; }
        public string? Reacciones { get; set; }

        public virtual AlergiaDto IdAlergiaNavigation { get; set; } = null!;

        public virtual PacienteDto IdPacienteNavigation { get; set; } = null!;
    }
}
