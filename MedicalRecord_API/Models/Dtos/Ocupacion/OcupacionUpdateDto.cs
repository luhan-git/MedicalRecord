namespace MedicalRecord_API.Models.Dtos.Ocupacion
{
    public class OcupacionUpdateDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Detalle { get; set; }
    }
}
