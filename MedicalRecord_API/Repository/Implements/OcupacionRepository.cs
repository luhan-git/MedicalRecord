using MedicalRecord_API.Models;
using MedicalRecord_API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Data;

namespace MedicalRecord_API.Repository.Implements
{
    public class OcupacionRepository : GenericRepository<Ocupacion>, IOcupacionRepository
    {
        private readonly DbhistoriasContext _context;
        private readonly ILogger<OcupacionRepository> _logger;

        public OcupacionRepository(DbhistoriasContext context, ILogger<OcupacionRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Ocupacion> Create(Ocupacion entity)
        {
            try
            {
                await using var connection = _context.Database.GetDbConnection();
                await connection.OpenAsync();

                using var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "InsertOcupacion_sp";
                command.Parameters.Add(new MySqlParameter("@nombre", entity.Nombre));
                command.Parameters.Add(new MySqlParameter("@detalle", entity.Detalle));

                var idOcupacionParam = new MySqlParameter("@id", MySqlDbType.Int32)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(idOcupacionParam);

                await command.ExecuteNonQueryAsync();

                var idOcupacion = (int)idOcupacionParam.Value;
                if (idOcupacion == -1)
                {
                    throw new Exception("El procedimiento almacenado InsertOcupacion_sp devolvió -1, indicando un error.");
                }

                _logger.LogInformation("Registro de inserción en Ocupacion con ID:{@id}", idOcupacion);

                return await _context.Set<Ocupacion>().FirstOrDefaultAsync(c => c.Id == idOcupacion) ?? new();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Excepción al intentar crear un registro en Ocupacion");
                throw;
            }
        }

        public async Task Update(Ocupacion entity)
        {
            try
            {
                await using var connection = _context.Database.GetDbConnection();
                await connection.OpenAsync();

                using var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UpdateOcupacion_sp";
                command.Parameters.Add(new MySqlParameter("@idUpdate", entity.Id));
                command.Parameters.Add(new MySqlParameter("@nombre", entity.Nombre));
                command.Parameters.Add(new MySqlParameter("@detalle", entity.Detalle));

                await command.ExecuteNonQueryAsync();

                _logger.LogInformation("Registro de actualización en Ocupacion con ID:{@idUpdate}", entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Excepción al intentar actualizar un registro en Ocupacion");
                throw;
            }
        }   
    }
}
