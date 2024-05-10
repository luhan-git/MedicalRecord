using MedicalRecord_API.Models;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Data;

namespace MedicalRecord_API.Repository.Implements
{
    public class ProcedimientoRepository : GenericRepository<Procedimiento>, IProcedimiento
    {
        private readonly DbhistoriasContext _context;
        private readonly ILogger<ProcedimientoRepository> _logger;

        public ProcedimientoRepository(DbhistoriasContext context, ILogger<ProcedimientoRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<int> Create(Procedimiento entity)
        {
            try
            {
                await using var connection = _context.Database.GetDbConnection();
                await connection.OpenAsync();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "InsertProcedimiento_sp";
                command.Parameters.Add(new MySqlParameter("@p_nombre_proce", entity.NombreProce));
                command.Parameters.Add(new MySqlParameter("@p_nemo_proce", entity.NemoProce));

                var idProcedimientosParam = new MySqlParameter("@p_id_proce", MySqlDbType.Int32)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(idProcedimientosParam);

                await command.ExecuteNonQueryAsync();

                var idProcedimientos = (int)idProcedimientosParam.Value;
                if (idProcedimientos == -1)
                {
                    throw new Exception("El procedimiento almacenado InsertProcedimiento_sp devolvió -1, indicando un error.");
                }

                _logger.LogInformation("Registro de inserción en Procedimientos con ID:{@p_id_proce}", idProcedimientos);
                
                return idProcedimientos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Excepción al intentar crear un registro en Procedimiento");
                throw;
            }
        }

        public async Task Update(Procedimiento entity)
        {
            try
            {
                await using var connection = _context.Database.GetDbConnection();
                await connection.OpenAsync();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UpdateProcedimiento_sp";
                command.Parameters.Add(new MySqlParameter("@p_id_proce", entity.IdProce));
                command.Parameters.Add(new MySqlParameter("@p_nombre_proce", entity.NombreProce));
                command.Parameters.Add(new MySqlParameter("@p_nemo_proce", entity.NemoProce));

                await command.ExecuteNonQueryAsync();

                _logger.LogInformation("Registro de actualización en Procedimientos con ID:{@p_id_proce}", entity.IdProce);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Excepción al intentar actualizar un registro en Procedimiento");
                throw;
            }

        }
    }
}
