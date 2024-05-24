using MedicalRecord_API.Models;
using MedicalRecord_API.Repository.Interfaces;

namespace MedicalRecord_API.Repository.Implements
{
    public class MedicamentoRepository : GenericRepository<Medicamento>, IMedicamentoRepository
    {
        public MedicamentoRepository(DbhistoriasContext context) : base(context)
        {
        }

        public Task<Medicamento> Create(Medicamento entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Medicamento entity)
        {
            throw new NotImplementedException();
        }
    }
}
