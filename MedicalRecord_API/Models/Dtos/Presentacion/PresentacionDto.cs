namespace MedicalRecord_API.Models.Dtos.Presentacion
{
    public class PresentacionDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Abreviatura { get; set; }
    }
}
