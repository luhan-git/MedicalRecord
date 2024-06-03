using MedicalRecord_API.Models;
using MedicalRecord_API.Repository.Interfaces;

namespace MedicalRecord_API.Repository.Implements
{
    public class PresentacionRepository : GenericRepository<Presentacion>, IPresentacionRepository
    {
        private readonly DbhistoriasContext _context;
        public PresentacionRepository(DbhistoriasContext context):base(context)
        {

            _context = context;

        }
        public async Task<Presentacion> Create(Presentacion entity)
        {
           await  _context.AddAsync(entity);
           await _context.SaveChangesAsync();
           return entity;
        }

        public async Task Update(Presentacion entity)
        {
             _context.Update(entity);
             await _context.SaveChangesAsync();
        }
    }
}
