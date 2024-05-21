using MedicalRecord_API.Models;
using MedicalRecord_API.Repository.Interfaces;

namespace MedicalRecord_API.Repository.Implements
{
    public class DiabetesRepository : GenericRepository<Diabete>, IDiabetesRepository
    {
        private readonly DbhistoriasContext _context;
        public DiabetesRepository(DbhistoriasContext context):base(context)
        {

            _context = context;

        }
        public Task<Diabete> Create(Diabete entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Diabete entity)
        {
            throw new NotImplementedException();
        }
    }
}
