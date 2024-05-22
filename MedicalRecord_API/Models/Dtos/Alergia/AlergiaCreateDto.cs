using System.ComponentModel.DataAnnotations;

namespace MedicalRecord_API.Models.Dtos.Alergia
{
    public class AlergiaCreateDto
    {
        //No sea nulo y sea obligatorio
        [Required(ErrorMessage = "El {0} es requerido.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "El {0} debe tener entre {2} y {1} caracteres.")]
        [RegularExpression(@"^[a-zA-ZáéíóúüÁÉÍÓÚÜñÑ,. ]*$", ErrorMessage = "El {0} solo puede contener letras, comas, puntos y espacios en blanco.")]
        public string Nombre { get; set; } = null!;
    }
}
