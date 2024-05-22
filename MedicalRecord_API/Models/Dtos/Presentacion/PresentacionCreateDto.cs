using System.ComponentModel.DataAnnotations;

namespace MedicalRecord_API.Models.Dtos.Presentacion
{
    public class PresentacionCreateDto
    {
        [Required(ErrorMessage = "El {0} es requerido.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "El {0} debe tener entre {2} y {1} caracteres.")]
        public string Nombre { get; set; } = null!;

        [StringLength(4, MinimumLength = 1, ErrorMessage = "La {0} debe tener entre {2} y {1} caracteres.")]
        public string? Abreviatura { get; set; }
    }
}
