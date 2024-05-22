using System.ComponentModel.DataAnnotations;

namespace MedicalRecord_API.Models.Dtos.Paciente
{
    public class PacienteCreateDto
    {
        [Required(ErrorMessage = "El campo Condicion es obligatorio.")]
        [RegularExpression("^[0-2]$", ErrorMessage = "El campo Condicion solo acepta los valores '0', '1' , '2'.")]
        public string Condicion { get; set; } = null!;

        [Required(ErrorMessage = "El {0} es requerido.")]
        [StringLength(25, ErrorMessage = "El {0} debe tener como máximo {1} caracteres.")]
        public string APaterno { get; set; } = null!;

        [Required(ErrorMessage = "El {0} es requerido.")]
        [StringLength(25, ErrorMessage = "El {0} debe tener como máximo {1} caracteres.")]
        public string AMaterno { get; set; } = null!;

        [Required(ErrorMessage = "El {0} es requerido.")]
        [StringLength(50, ErrorMessage = "El {0} debe tener como máximo {1} caracteres.")]
        public string Nombres { get; set; } = null!;

        [Required(ErrorMessage = "El {0} es requerido.")]
        [RegularExpression("^[0-3]$", ErrorMessage = "{0} fuera de rango (0-4)")]
        public string TipoDocumento { get; set; } = null!;

        [Required(ErrorMessage = "El {0} es requerido.")]
        [StringLength(12, ErrorMessage = "El {0} debe tener como máximo {1} caracteres.")]
        public string NumeroDocumento { get; set; } = null!;

        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El {0} es requerido.")]
        [RegularExpression("^[FM]$", ErrorMessage = "El {0} solo puede contener 'F' o 'M'")]
        public string Sexo { get; set; } = null!;

        [Required(ErrorMessage = "El {0} es requerido.")]
        [RegularExpression("^[0-4]$", ErrorMessage = "{0} fuera de rango (0-4)")]
        public string EstadoCivil { get; set; } = null!;

        [Required(ErrorMessage = "El {0} es requerido.")]
        [RegularExpression("^[0-8]$", ErrorMessage = "{0} fuera de rango (0-8)")]
        public string GrupoSanguineo { get; set; } = null!;

        [Required(ErrorMessage = "El {0} es requerido.")]
        [RegularExpression("^[0-1]$", ErrorMessage = "{0} fuera de rango (0-1)")]
        public string Nacionalidad { get; set; } = null!;

        [Range(1, 25, ErrorMessage = "Identificador fuera del rango")]
        public int IdDepartamento { get; set; }

        [Range(1, 193, ErrorMessage = "Identificador fuera del rango")]
        public int IdProvincia { get; set; }

        [Range(1, 1832, ErrorMessage = "Identificador fuera del rango")]
        public int IdDistrito { get; set; }

        [StringLength(60, ErrorMessage = "El {0} debe tener como máximo {1} caracteres.")]
        [RegularExpression(@"^[a-zA-Z0-9\s.,#-áéíóúÁÉÍÓÚüÜñÑ]*$", ErrorMessage = "La {0} debe tener un formato válido de dirección.")]
        public string? Direccion { get; set; }

        [StringLength(20, ErrorMessage = "El {0} debe tener como máximo {1} caracteres.")]
        [RegularExpression(@"^[0-9\s]*$", ErrorMessage = "El campo {0} solo puede contener números y espacios en blanco.")]
        public string? Telefono { get; set; }

        [StringLength(20, ErrorMessage = "El {0} debe tener como máximo {1} caracteres.")]
        [RegularExpression(@"^[0-9\s]*$", ErrorMessage = "El campo {0} solo puede contener números y espacios en blanco.")]
        public string? Celular { get; set; }

        [StringLength(40, ErrorMessage = "El {0} debe tener como máximo {1} caracteres.")]
        public string? CentroTrabajo { get; set; }

        public bool? Asegurado { get; set; }

        public int? IdCiaSeguro { get; set; }

        [StringLength(10, ErrorMessage = "El {0} debe tener como máximo {1} caracteres.")]
        public string? NumeroCarnet { get; set; }

        [StringLength(50, ErrorMessage = "El {0} debe tener como máximo {1} caracteres.")]
        public string? Contacto { get; set; }

        public int? IdParentesco { get; set; }

        [RegularExpression(@"^[0-9\s]*$", ErrorMessage = "El campo {0} solo puede contener números y espacios en blanco.")]
        [StringLength(20, ErrorMessage = "El {0} debe tener como máximo {1} caracteres.")]
        public string? TelefonoContacto { get; set; }

        [RegularExpression(@"^[0-9\s]*$", ErrorMessage = "El campo {0} solo puede contener números y espacios en blanco.")]
        [StringLength(20, ErrorMessage = "El {0} debe tener como máximo {1} caracteres.")]
        public string? CelularContacto { get; set; }

        [StringLength(200, ErrorMessage = "El {0} debe tener como máximo {1} caracteres.")]
        public string? Perfil { get; set; }

        [StringLength(150, ErrorMessage = "Los {0} debe tener como máximo {1} caracteres.")]
        [RegularExpression(@"^[a-zA-ZáéíóúüÁÉÍÓÚÜñÑ,. ]*$", ErrorMessage = "El {0} solo puede contener letras, comas, puntos y espacios en blanco.")]
        public string? AntecedentesClinicos { get; set; }

        [StringLength(150, ErrorMessage = "Los {0} debe tener como máximo {1} caracteres.")]
        [RegularExpression(@"^[a-zA-ZáéíóúüÁÉÍÓÚÜñÑ,. ]*$", ErrorMessage = "El {0} solo puede contener letras, comas, puntos y espacios en blanco.")]
        public string? AntecedentesFamiliares { get; set; }

        public int IdOcupacion { get; set; }

        [Required(ErrorMessage = "El {0} es requerido.")]
        [RegularExpression("^[0-2]$", ErrorMessage = "{0} fuera de rango (0-2)")]
        public string PresionArterial { get; set; } = null!;

        [StringLength(6, ErrorMessage = "El {0} debe tener como máximo {1} caracteres.")]
        public string? CampoVisual { get; set; }

        [EmailAddress(ErrorMessage = "El {0} no es una dirección de correo electrónico válida.")]
        [StringLength(80, ErrorMessage = "El {0} debe tener como máximo {1} caracteres.")]
        public string? Email { get; set; }

        public bool? Diabetico { get; set; }

        public int? IdDiabetes { get; set; }

        public bool? Alergico { get; set; }
    }
}
