using System.ComponentModel.DataAnnotations;

namespace MedicalRecord_API.Models.Dtos.Parentesco
{
    public class ParentescoCreateDto
    {
        [Required(ErrorMessage = "El {0} es requerido.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "El {0} debe tener entre {2} y {1} caracteres.")]
        public string Valor { get; set; } = null!;
    }
}
