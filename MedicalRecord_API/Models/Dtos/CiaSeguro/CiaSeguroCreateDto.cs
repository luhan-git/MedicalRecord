using System.ComponentModel.DataAnnotations;

namespace MedicalRecord_API.Models.Dtos.CiaSeguro
{
    public class CiaSeguroCreateDto
    {
        public string Nombre { get; set; } = null!;
        public string? Abreviatura { get; set; }
    }
}
