using System.ComponentModel.DataAnnotations;

namespace MedicalRecord_API.Models.Dtos.Directorio
{
    public class DirectorioUpdateDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "Identificador fuera del rango")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El {0} es requerido.")]
        [StringLength(80, MinimumLength = 5, ErrorMessage = "El {0} debe tener entre {2} y {1} caracteres.")]
        [RegularExpression(@"^[a-zA-ZáéíóúüÁÉÍÓÚÜñÑ,. ]*$", ErrorMessage = "El {0} solo puede contener letras, comas, puntos y espacios en blanco.")]
        public string Nombre { get; set; } = null!;

        [StringLength(80, ErrorMessage = "El {0} debe tener como máximo {1} caracteres.")]
        public string? Representante { get; set; }

        [RegularExpression(@"^\d{12}$", ErrorMessage = "El campo {0} debe tener un formato válido de número de teléfono.")]
        public string? Telefono { get; set; }

        [RegularExpression(@"^\d{9}$", ErrorMessage = "El campo {0} debe tener un formato válido de número de teléfono.")]
        public string? Celular { get; set; }

        [EmailAddress(ErrorMessage = "El {0} no es una dirección de correo electrónico válida.")]
        public string? Email { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9\s.,#-áéíóúÁÉÍÓÚüÜñÑ]*$", ErrorMessage = "La {0} debe tener un formato válido de dirección.")]
        public string? Direccion { get; set; }

        public bool? Estado { get; set; }
    }
}
