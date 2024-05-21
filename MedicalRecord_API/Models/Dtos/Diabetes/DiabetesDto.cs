namespace MedicalRecord_API.Models.Dtos.Diabetes
{
    public class DiabetesDto
    {
        public int Id { get; set; }

        public string Tipo { get; set; } = null!;

        public string? Detalle { get; set; }
    }
}
