using MedicalRecord_API.Models;
using System.Text.RegularExpressions;

namespace MedicalRecord_API.Repository.Interfaces
{
    public interface IMedicoRepository:IGenericRepository<Medico>
    {
        Task<int> Create (Medico entity);
        Task<Medico> Update(Medico entity);
    }
}
