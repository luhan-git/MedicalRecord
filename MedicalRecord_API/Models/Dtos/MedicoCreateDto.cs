namespace MedicalRecord_API.Models.Dtos
{
    public class MedicoCreateDto
    {
        public string NombreMed { get; set; } = null!;

        public string? EspeMed { get; set; }

        public string? NroCmed { get; set; }
    }
}
