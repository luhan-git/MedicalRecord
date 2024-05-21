using System.ComponentModel.DataAnnotations;

namespace MedicalRecord_API.Utils.Recursos.Interfaces
{
    public interface IRegularExpression
    {
        Task<bool> CampoTextoValidado(int minLength, int maxLength);
    }
}
