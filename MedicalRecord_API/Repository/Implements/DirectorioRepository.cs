using MedicalRecord_API.Models;
using MedicalRecord_API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Data;

namespace MedicalRecord_API.Repository.Implements
{
    public class DirectorioRepository : GenericRepository<Directorio>, IDirectorioRepository
    {
        private readonly DbhistoriasContext _context;
        private readonly ILogger<DirectorioRepository> _logger;

        public DirectorioRepository(DbhistoriasContext context, ILogger<DirectorioRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Directorio> Create(Directorio entity)
        {
            try
            {
                await using var connection = _context.Database.GetDbConnection();
                await connection.OpenAsync();

                using var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "InsertDirectorio_sp";
                command.Parameters.Add(new MySqlParameter("@nombre", entity.Nombre));
                command.Parameters.Add(new MySqlParameter("@representante", entity.Representante));
                command.Parameters.Add(new MySqlParameter("@telefono", entity.Telefono));
                command.Parameters.Add(new MySqlParameter("@celular", entity.Celular));
                command.Parameters.Add(new MySqlParameter("@email", entity.Email));
                command.Parameters.Add(new MySqlParameter("@direccion", entity.Direccion));

                var idDirectorioParam = new MySqlParameter("@id", MySqlDbType.Int32)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(idDirectorioParam);

                await command.ExecuteNonQueryAsync();

                var idDirectorio = (int)idDirectorioParam.Value;
                if (idDirectorio == -1)
                {
                    throw new Exception("El procedimiento almacenado InsertDirectorio_sp devolvió -1, indicando un error.");
                }

                _logger.LogInformation("Registro en Directorio con id: {@id}", idDirectorio);

                return await _context.Set<Directorio>().FirstOrDefaultAsync(c => c.Id == idDirectorio) ?? new();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en create directorio");
                throw;
            }
        }

        public async Task Update(Directorio entity)
        {
            try
            {
                await using var connection = _context.Database.GetDbConnection();
                await connection.OpenAsync();
                using var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UpdateDirectorio_sp";
                command.Parameters.Add(new MySqlParameter("@idUpdate", entity.Id));
                command.Parameters.Add(new MySqlParameter("@nombre", entity.Nombre));
                command.Parameters.Add(new MySqlParameter("@representante", entity.Representante));
                command.Parameters.Add(new MySqlParameter("@telefono", entity.Telefono));
                command.Parameters.Add(new MySqlParameter("@celular", entity.Celular));
                command.Parameters.Add(new MySqlParameter("@email", entity.Email));
                command.Parameters.Add(new MySqlParameter("@direccion", entity.Direccion));

                await command.ExecuteNonQueryAsync();

                _logger.LogInformation("Registro de actualización en Directorio con id: {@id}", entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en update directorio");
                throw;
            }
        }
    }
}
