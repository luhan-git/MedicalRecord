using MedicalRecord_API.Models;
using MedicalRecord_API.Repository;
using MedicalRecord_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MedicalRecord_API.Services.Implements
{
    public class AntecedenteService : IAntecedenteService
    {
        private readonly IGenericRepository<Antecedente> _repo;
        public AntecedenteService(IGenericRepository<Antecedente> repo)
        {
            _repo = repo;
        }
        public async Task<Antecedente> GetAntecendente(Expression<Func<Antecedente, bool>>? filters = null)
        {
            IQueryable<Antecedente> query = await _repo.Query(filters);
            query=query.Include(x => x.Detallealergia);
            return await query.FirstOrDefaultAsync();
        }
    }
}
