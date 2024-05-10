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

        public async Task<int> Create(Ocupacion entity)
        {
            try
            {
                await using var connection = _context.Database.GetDbConnection();
                await connection.OpenAsync();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "InsertOcupacion_sp";
                command.Parameters.Add(new MySqlParameter("@p_nombre_ocupa", entity.NombreOcupa));
                command.Parameters.Add(new MySqlParameter("@p_detalle_ocupa", entity.NombreOcupa));

                var idOcupacionParam = new MySqlParameter("@p_id_Ocupa", MySqlDbType.Int32)
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

                _logger.LogInformation("Registro de inserción en Ocupacion con ID:{@p_id_ocupacion}", idOcupacion);
                
                return idOcupacion;
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

                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UpdateOcupacion_sp";
                command.Parameters.Add(new MySqlParameter("@p_id_ocupa", entity.IdOcupa));
                command.Parameters.Add(new MySqlParameter("@p_nombre_ocupa", entity.NombreOcupa));
                command.Parameters.Add(new MySqlParameter("@p_detalle_ocupa", entity.NombreOcupa));

                await command.ExecuteNonQueryAsync();

                _logger.LogInformation("Registro de actualización en Ocupacion con ID:{@p_id_ocupacion}", entity.IdOcupa);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Excepción al intentar actualizar un registro en Ocupacion");
                throw;
            }
        }
    }
}
