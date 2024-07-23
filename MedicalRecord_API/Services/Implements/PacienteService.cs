using MedicalRecord_API.Models;
using MedicalRecord_API.Repository;
using MedicalRecord_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Paciente> Create(Paciente paciente)
        {
            DateTime fechaNacimiento = paciente.FechaNacimiento;
            int edad = DateTime.Today.Year - fechaNacimiento.Year;
            if (fechaNacimiento.Date > DateTime.Today.AddYears(-edad))
                edad--;
            bool isAsegurado=paciente.IdSeguro!=null;
            bool isAlergico=false;
            bool isDiabetico=false;
            if(paciente.Antecedente!=null)
            {
                isAlergico = paciente.Antecedente.Detallealergia.Count > 0;
                isDiabetico = paciente.Antecedente.IdDiabete!= null;
            }
            
            paciente.Edad = edad.ToString();
            paciente.IsAsegurado = isAsegurado;
            paciente.IsAlergico = isAlergico;
            paciente.IsDiabetico = isDiabetico;
            try
            {
                Paciente created= await _repo.Create(paciente);
                return created;
            }
            catch
            {
                throw;
            }
        }
    }
}
