using MedicalRecord_API.Models;

namespace MedicalRecord_API.Repository.Interfaces
{
    public interface ICiaSeguroRepository : IGenericRepository<Ciaseguro>
    {
        Task<Ciaseguro> Create(Ciaseguro entity);
        Task Update(Ciaseguro entity);
    }
}
