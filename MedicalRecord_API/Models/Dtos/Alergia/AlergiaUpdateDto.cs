using System.ComponentModel.DataAnnotations;

namespace MedicalRecord_API.Models.Dtos.Alergia
{
    public class AlergiaUpdateDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "El identificador debe ser un entero positivo.")]
        public int Id { get; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [RegularExpression(@"^[a-zA-ZáéíóúüÁÉÍÓÚÜñÑ,. ]*$", ErrorMessage = "El campo {0} solo puede contener letras, comas, puntos y espacios en blanco.")]
        public string Nombre { get; init; }
    }
}
