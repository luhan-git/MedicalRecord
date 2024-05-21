using MedicalRecord_API.Models;
using MedicalRecord_API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Data;

namespace MedicalRecord_API.Repository.Implements
{
    public class ExamenLaboratorioRepository: GenericRepository<Examenlaboratorio>, IExamenLaboratorioRepository
    {
        private readonly DbhistoriasContext _context;
        private readonly ILogger<ExamenLaboratorioRepository> _logger;

        public ExamenLaboratorioRepository(DbhistoriasContext context, ILogger<ExamenLaboratorioRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }

        public Task<Examenlaboratorio> Create(Examenlaboratorio entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Examenlaboratorio entity)
        {
            throw new NotImplementedException();
        }
    }
}
