using System.ComponentModel.DataAnnotations;
using MedicalRecord_API.Utils.Recursos.Interfaces;
using MedicalRecord_API.Utils.Recursos.Implements;

namespace MedicalRecord_API.Models.Dtos.Alergia
{
    public class AlergiaCreateDto
    {

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [RegularExpression(@"^[a-zA-ZáéíóúüÁÉÍÓÚÜñÑ,. ]*$", ErrorMessage = "El campo {0} solo puede contener letras, comas, puntos y espacios en blanco.")]
        public string Nombre { get; init; }//No sea nulo y sea obligatorio
    }
}
