using MedicalRecord_API.Models;
using MedicalRecord_API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Data;

namespace MedicalRecord_API.Repository.Implements
{
    public class PacienteRepository : GenericRepository<Paciente>, IPacienteRepository
    {
        private readonly DbhistoriasContext _context;
        private readonly ILogger<PacienteRepository> _logger;

        public PacienteRepository(DbhistoriasContext context, ILogger<PacienteRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Paciente> Create(Paciente entity)
        {

            using var transaction = _context.Database.BeginTransaction();
            Paciente paciente;
            try
            {
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
                paciente = entity;
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            return paciente;
        }

        public Task Update(Paciente entity)
        {
            throw new NotImplementedException();
        }
    }
}
