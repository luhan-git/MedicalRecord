namespace MedicalRecord_API.Models.Dtos.ExamenLaboratorio
{
    public class ExamenLaboratorioDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Abreviatura { get; set; }
    }
}
