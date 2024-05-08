using System.ComponentModel.DataAnnotations;

namespace MedicalRecord_API.Models.Dtos
{
    public class MedicoCreateDto
    {
        [Required ]
        [StringLength (50)]
        public string NombreMed { get; set; } = null!;
        [StringLength(20)]
        public string? EspeMed { get; set; } 

        [StringLength (6)]
        public string? NroCmed { get; set; }
    }
}
