using MedicalRecord_API.Models;
using MedicalRecord_API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Data;


namespace MedicalRecord_API.Repository.Implements
{
    public class CiaSeguroRepository: GenericRepository<Ciaseguro>, ICiaSeguroRepository
    {
        private readonly DbhistoriasContext _context;
        private readonly ILogger<CiaSeguroRepository> _logger;

        public CiaSeguroRepository(DbhistoriasContext context, ILogger<CiaSeguroRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<int> Create(Ciaseguro entity)
        {
            try
            {
                await using var connection = _context.Database.GetDbConnection();
                await connection.OpenAsync();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "InsertCia_sp";
                command.Parameters.Add(new MySqlParameter("@p_nombre_cia", entity.NombreCia));
                command.Parameters.Add(new MySqlParameter("@p_nemo_cia", entity.NemoCia));

                var idCiaSegurosParam = new MySqlParameter("@p_id_cia", MySqlDbType.Int32)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(idCiaSegurosParam);

                await command.ExecuteNonQueryAsync();

                var idCiaSeguros = (int)idCiaSegurosParam.Value;
                if (idCiaSeguros == -1)
                {
                    throw new Exception("El procedimiento almacenado InsertCia_sp devolvió -1, indicando un error.");
                }

                _logger.LogInformation("Registro de inserción en CiaSeguros con ID:{@p_id_cia}", idCiaSeguros);
                
                return idCiaSeguros;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Excepción al intentar crear un registro en CiaSeguro");
                throw;
            }
        }

        public async Task Update(Ciaseguro entity)
        {
            try
            {
                await using var connection = _context.Database.GetDbConnection();
                await connection.OpenAsync();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UpdateCia_sp";
                command.Parameters.Add(new MySqlParameter("@p_id_cia", entity.IdCia));
                command.Parameters.Add(new MySqlParameter("@p_nombre_cia", entity.NombreCia));
                command.Parameters.Add(new MySqlParameter("@p_nemo_cia", entity.NemoCia));

                await command.ExecuteNonQueryAsync();
                _logger.LogInformation("Registro de actualización en CiaSeguros con ID:{idCiaSeguros}", entity.IdCia);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Excepción al intentar actualizar un registro en CiaSeguro");
                throw;
            }
        }
    }
}
