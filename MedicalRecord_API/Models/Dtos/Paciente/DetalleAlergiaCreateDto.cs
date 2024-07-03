namespace MedicalRecord_API.Models.Dtos.Paciente
{
    public class DetalleAlergiaCreateDto
    {
        public int IdAlergia { get; set; }
        public int IdAntecedente { get; set; }
        public string Alergia { get; set; } = null!;
        public string? Reacciones { get; set; }
    }
}
