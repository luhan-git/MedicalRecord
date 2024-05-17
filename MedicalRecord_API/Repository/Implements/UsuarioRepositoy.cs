using MedicalRecord_API.Models;
using MedicalRecord_API.Repository.Interfaces;

namespace MedicalRecord_API.Repository.Implements
{
    public class UsuarioRepositoy : GenericRepository<Usuario>, IUsuarioRepository
    {
        private readonly DbhistoriasContext _context;
        public UsuarioRepositoy(DbhistoriasContext context):base(context)
        {

            _context = context;

        }
        public Task<int> Create(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Usuario entity)
        {
            throw new NotImplementedException();
        }
    }
}
