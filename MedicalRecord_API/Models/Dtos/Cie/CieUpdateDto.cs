using System.ComponentModel.DataAnnotations;

namespace MedicalRecord_API.Models.Dtos.Cie
{
    public class CieUpdateDto
    {
        [Required]
        public int IdCie { get; set; }
        [Required]
        [StringLength(5)]
        public string Codcie { get; set; } = null!;

        public string Enfermedad { get; set; } = null!;
    }
}
