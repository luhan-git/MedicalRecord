namespace MedicalRecord_API.Models.Dtos.Medico
{
    public class MedicoUpdateDto
    {
        public int IdMedico { get; set; }

        public string NombreMed { get; set; } = null!;

        public string? EspeMed { get; set; }

        public string? NroCmed { get; set; }

        public bool? Estado { get; set; }
    }
}
