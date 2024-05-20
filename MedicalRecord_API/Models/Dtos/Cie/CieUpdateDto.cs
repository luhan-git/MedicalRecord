using System.ComponentModel.DataAnnotations;

namespace MedicalRecord_API.Models.Dtos.Cie
{
    public class CieUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(5)]
        public string Codigo { get; set; } = null!;

        public string Enfermedad { get; set; } = null!;
    }
}
