using System.ComponentModel.DataAnnotations;

namespace MedicalRecord_API.Models.Dtos.Cie
{
    public class CieCreateDto
    {
        [Required]
        [StringLength(5)]
        public string Codigo { get; set; } = null!;
        [Required]
        public string Enfermedad { get; set; } = null!;
    }
}
