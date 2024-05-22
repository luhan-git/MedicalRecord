using System.ComponentModel.DataAnnotations;
using MedicalRecord_API.Utils.Recursos.Interfaces;
using MedicalRecord_API.Utils.Recursos.Implements;

namespace MedicalRecord_API.Models.Dtos.Alergia
{
    public class AlergiaCreateDto
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string? Nombre { get; set; }
    }
}
