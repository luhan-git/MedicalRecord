namespace MedicalRecord_API.Models.Dtos.Laboratorio
{
    public class LaboratorioDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Abreviatura { get; set; }
    }
}
