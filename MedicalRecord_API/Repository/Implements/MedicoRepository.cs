using MedicalRecord_API.Models;
using MedicalRecord_API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Data;

namespace MedicalRecord_API.Repository.Implements
{
    public class MedicoRepository : GenericRepository<Medico>, IMedicoRepository
    {
        private readonly DbhistoriasContext _context;
        private readonly ILogger<MedicoRepository> _logger;

        public MedicoRepository(DbhistoriasContext context, ILogger<MedicoRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<int> Create(Medico entity)
        {
            try
            {
                await using var connection = _context.Database.GetDbConnection();
                await connection.OpenAsync();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "InsertMedico";

                command.Parameters.Add(new MySqlParameter("@nombre_med", entity.NombreMed));
                command.Parameters.Add(new MySqlParameter("@espe_med", entity.EspeMed));
                command.Parameters.Add(new MySqlParameter("@nro_cmed", entity.NroCmed));

                var idMedicoParam = new MySqlParameter("@id_medico", MySqlDbType.Int32)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(idMedicoParam);

                await command.ExecuteNonQueryAsync();

                var idMedico = (int)idMedicoParam.Value;
                if (idMedico == -1)
                {
                    throw new Exception("El procedimiento almacenado InserMedico devolvió -1, indicando un error.");
                }
                _logger.LogInformation("Registro de inserción en Medico con ID: {idMedico}", idMedico);
                return idMedico;
            }
            catch (Exception ex)
            {
                {
                    _logger.LogError(ex, "Error al intentar crear un médico");
                    throw;
                }

            }
        }

        public async Task Update(Medico entity)
        {
            try
            {

            string sql = "CALL UpdateMedico (@id_medico_update, @nombre_med, @espe_med,@nro_cmed,@estado)";
            await _context.Database.ExecuteSqlRawAsync(sql,
                new MySqlParameter("@id_medico_update", entity.IdMedico),
                new MySqlParameter("@nombre_med", entity.NombreMed),
                new MySqlParameter("@espe_med", entity.EspeMed),
                new MySqlParameter("@nro_cmed", entity.NroCmed),
                new MySqlParameter("@estado", entity.Estado)
                );
                _logger.LogInformation("Se actualizó un medico con ID: {idMedico}",entity.IdMedico);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al intentar actualizar un médico");
                throw;
            }

        }
    }
}

