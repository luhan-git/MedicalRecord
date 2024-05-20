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
        public Task<Presentacion> Create(Presentacion entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Presentacion entity)
        {
            throw new NotImplementedException();
        }
    }
}
