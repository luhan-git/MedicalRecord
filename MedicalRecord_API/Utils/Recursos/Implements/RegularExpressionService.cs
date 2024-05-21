using MedicalRecord_API.Utils.Recursos.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MedicalRecord_API.Utils.Recursos.Implements
{
    public class RegularExpressionService : RegularExpressionAttribute, IRegularExpression
    {
        public RegularExpressionService(int minLength, int maxLength)
            : base("^[a-zA-ZáéíóúÁÉÍÓÚñÑ,\\. ]{" + minLength + "," + maxLength + "}$")
        {
            ErrorMessage = "El campo {0} debe tener entre " + minLength + " y " + maxLength + " caracteres y no debe contener caracteres especiales.";
        }

        public Task<bool> CampoTextoValidado(int minLength, int maxLength)
        {
            return Task.FromResult(true);
        }
    }
}
