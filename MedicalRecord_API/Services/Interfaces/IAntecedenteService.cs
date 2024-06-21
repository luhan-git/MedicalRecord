using MedicalRecord_API.Models;
using System.Linq.Expressions;

namespace MedicalRecord_API.Services.Interfaces
{
    public interface IAntecedenteService
    {
        Task<Antecedente> GetAntecendente(Expression<Func<Antecedente, bool>>? filters = null);
    }
}
