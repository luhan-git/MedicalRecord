namespace MedicalRecord_API.Models.Dtos.Procedimiento
{
    public class ProcedimientoCreateDto
    {
        public string Nombre { get; set; } = null!;

        public string? Abreviatura { get; set; }
    }
}
