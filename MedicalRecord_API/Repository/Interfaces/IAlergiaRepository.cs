using MedicalRecord_API.Models;

namespace MedicalRecord_API.Repository.Interfaces
{
    public interface IAlergiaRepository: IGenericRepository<Alergium>
    {
        Task<Alergium> Create(Alergium entity);
        Task Update(Alergium entity);
    }
}
