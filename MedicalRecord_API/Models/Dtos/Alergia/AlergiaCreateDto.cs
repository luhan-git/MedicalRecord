using System.ComponentModel.DataAnnotations;
using MedicalRecord_API.Utils.Recursos.Implements;
using MedicalRecord_API.Utils.Recursos.Interfaces;

namespace MedicalRecord_API.Models.Dtos.Alergia
{
    public class AlergiaCreateDto
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [RegularExpressionService(5, 50)]
        public string? Nombre { get; set; }
    }
}
