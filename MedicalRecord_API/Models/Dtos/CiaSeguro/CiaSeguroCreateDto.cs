using System.ComponentModel.DataAnnotations;

namespace MedicalRecord_API.Models.Dtos.CiaSeguro
{
    public class CiaSeguroCreateDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
        public string Nombre { get; set; } = null!;

        [MaxLength(20, ErrorMessage = "La abreviatura no puede tener mas de 20 caracteres.")]
        public string? Abreviatura { get; set; }
    }
}
