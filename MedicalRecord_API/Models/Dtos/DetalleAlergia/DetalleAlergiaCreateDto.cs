namespace MedicalRecord_API.Models.Dtos.DetalleAlergia
{
    public class DetalleAlergiaCreateDto
    {
        public int IdAlergia { get; set; }
        public int IdPaciente { get; set; }
        public string? Reacciones { get; set; }
    }
}
