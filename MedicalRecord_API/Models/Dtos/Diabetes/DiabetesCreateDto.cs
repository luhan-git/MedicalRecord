namespace MedicalRecord_API.Models.Dtos.Diabetes
{
    public class DiabetesCreateDto
    {
        public string Tipo { get; set; } = null!;

        public string? Detalle { get; set; }
    }
}
