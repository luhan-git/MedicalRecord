using MedicalRecord_API.Models;
using MedicalRecord_API.Repository.Interfaces;

namespace MedicalRecord_API.Repository.Implements
{
    public class DiabetesRepository : GenericRepository<Diabete>, IDiabetesRepository
    {
        private readonly DbhistoriasContext _context;
        public DiabetesRepository(DbhistoriasContext context) : base(context)
        {

            _context = context;

        }
        public async Task<Diabete> Create(Diabete entity)
        {
            await _context.Diabetes.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Diabete entity)
        {
            _context.Diabetes.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
