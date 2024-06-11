namespace MedicalRecord_API.Models.Dtos.CiaSeguro
{
    public class CiaSeguroUpdateDto
    {

        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Abreviatura { get; set; }
    }
}
