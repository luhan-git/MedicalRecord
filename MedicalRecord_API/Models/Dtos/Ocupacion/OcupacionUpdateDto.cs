using System.ComponentModel.DataAnnotations;

namespace MedicalRecord_API.Models.Dtos.Ocupacion
{
    public class OcupacionUpdateDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "Identificador fuera del rango")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El {0} es requerido.")]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "El {0} debe tener entre {2} y {1} caracteres.")]
        [RegularExpression(@"^[a-zA-ZáéíóúüÁÉÍÓÚÜñÑ,. ]*$", ErrorMessage = "El {0} solo puede contener letras, comas, puntos y espacios en blanco.")]
        public string Nombre { get; set; } = null!;

        [StringLength(50, MinimumLength = 5, ErrorMessage = "El {0} debe tener entre {2} y {1} caracteres.")]
        [RegularExpression(@"^[a-zA-ZáéíóúüÁÉÍÓÚÜñÑ,. ]*$", ErrorMessage = "El {0} solo puede contener letras, comas, puntos y espacios en blanco.")]
        public string? Detalle { get; set; }
    }
}
