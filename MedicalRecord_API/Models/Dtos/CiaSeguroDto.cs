namespace MedicalRecord_API.Models.Dtos
{
    public class CiaseguroDto
    {
        public int IdCiaSeguro { get; set; }
        public string NombreCia { get; set; } = null!;
        public string? NemoCia { get; set; }
    }
}
