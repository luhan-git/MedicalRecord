using MedicalRecord_API.Models;
using MedicalRecord_API.Repository;
using MedicalRecord_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection.Metadata;

namespace MedicalRecord_API.Services.Implements
{
    public class PacienteService : IPacienteService
    {
        private readonly IGenericRepository<Paciente> _repo;
        public PacienteService(IGenericRepository<Paciente> repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<Paciente>> List()
        {
            IQueryable<Paciente> pacientes = await _repo.Query();
            return await pacientes.ToListAsync();
        }
        public async Task<Paciente> GetById(int id)
        {
            IQueryable<Paciente> query =await  _repo.Query(p => p.Id == id);
            query = query.Include(d => d.IdDepartamentoNavigation)
                         .Include(p => p.IdProvinciaNavigation)
                         .Include(d => d.IdDistritoNavigation)
                         .Include(s => s.IdSeguroNavigation)
                         .Include(o => o.IdOcupacionNavigation)
                         .Include(c => c.Contactos)
                         .ThenInclude(c => c.IdParentescoNavigation)
                         .Include(a => a.Antecedente)
                         .ThenInclude(a => a.IdDiabeteNavigation)
                         .Include(a=> a.Antecedente)
                         .ThenInclude(a=> a.Detallealergia);
                         
                         
            return await query.FirstAsync();
        }
        
    }
}
