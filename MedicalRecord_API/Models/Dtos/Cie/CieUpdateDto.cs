using System.ComponentModel.DataAnnotations;

namespace MedicalRecord_API.Models.Dtos.Cie
{
    public class CieUpdateDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "Identificador fuera del rango")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El {0} es requerido.")]
        [StringLength(5, ErrorMessage = "El {0} debe tener como máximo {1} caracteres.")]
        public string Codigo { get; set; } = null!;

        [Required(ErrorMessage = "El {0} es requerido.")]
        [StringLength(120, MinimumLength = 5, ErrorMessage = "El {0} debe tener entre {2} y {1} caracteres.")]
        [RegularExpression(@"^[a-zA-ZáéíóúüÁÉÍÓÚÜñÑ,. ]*$", ErrorMessage = "El {0} solo puede contener letras, comas, puntos y espacios en blanco.")]
        public string Enfermedad { get; set; } = null!;
    }
}
