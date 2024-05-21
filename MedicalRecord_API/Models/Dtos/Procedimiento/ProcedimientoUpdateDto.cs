namespace MedicalRecord_API.Models.Dtos.Procedimiento
{
    public class ProcedimientoUpdateDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Abreviatura { get; set; }
    }
}
