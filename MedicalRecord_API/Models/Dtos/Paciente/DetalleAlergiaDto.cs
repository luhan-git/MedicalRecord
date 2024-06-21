namespace MedicalRecord_API.Models.Dtos.Paciente
{
    public class DetalleAlergiaDto
    {
        public int Id { get; set; }

        public int IdAlergia { get; set; }
        public string Alergia { get; set; } = null!;
        public int IdAntecedente { get; set; }
        public string? Reacciones { get; set; }
        public bool? IsDelete { get; set; }

    }
}
