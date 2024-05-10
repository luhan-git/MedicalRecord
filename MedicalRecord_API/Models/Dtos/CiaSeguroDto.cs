namespace MedicalRecord_API.Models.Dtos
{
    public class CiaSeguroDto
    {
        public int IdCiaSeguro { get; set; }
        public string NombreCia { get; set; } = null!;
        public string? NemoCia { get; set; }
    }
}
