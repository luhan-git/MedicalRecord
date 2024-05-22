using MedicalRecord_API.Models;
using MedicalRecord_API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Data;

namespace MedicalRecord_API.Repository.Implements
{
    public class AlergiaRepository: GenericRepository<Alergium>, IAlergiaRepository
    {
        private readonly DbhistoriasContext _context;
        private readonly ILogger<AlergiaRepository> _logger;

        public AlergiaRepository (DbhistoriasContext context, ILogger<AlergiaRepository> logger): base(context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Alergium> Create(Alergium entity)
        {
            try
            {
                await using var connection = _context.Database.GetDbConnection();
                await connection.OpenAsync();

                using var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "InsertAlergia_sp";
                command.Parameters.Add(new MySqlParameter("@nombre", entity.Nombre));

                var idAlergiaParam = new MySqlParameter("@id", MySqlDbType.Int32)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(idAlergiaParam);

                await command.ExecuteNonQueryAsync();

                var idAlergia = (int)idAlergiaParam.Value;
                if (idAlergia == -1)
                {
                    throw new Exception("El procedimiento almacenado InsertAlergia_sp devolvió -1, indicando un error.");
                }

                _logger.LogInformation("Registro de inserción en Alergia con ID:{@id}", idAlergia);

                return await _context.Set<Alergium>().FirstOrDefaultAsync(a => a.Id == idAlergia) ?? new();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Excepción al intentar crear un registro en Alergia");
                throw;
            }
        }

        public async Task Update(Alergium entity)
        {
            try
            {
                await using var connection = _context.Database.GetDbConnection();
                await connection.OpenAsync();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UpdateAlergia_sp";
                command.Parameters.Add(new MySqlParameter("@idUpdate", entity.Id));
                command.Parameters.Add(new MySqlParameter("@nombre", entity.Nombre));

                await command.ExecuteNonQueryAsync();

                _logger.LogInformation("Registro de actualización en Alergia con ID:{@id}", entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Excepción al intentar actualizar un registro en Alergia");
                throw;
            }
        }

        public async Task CreateDetalle(Detallealergium entity)
        {
            try
            {
                await using var connection = _context.Database.GetDbConnection();
                await connection.OpenAsync();

                using var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "InsertDetalleAlergia_sp";
                command.Parameters.Add(new MySqlParameter("@idAlergia", entity.IdAlergia));
                command.Parameters.Add(new MySqlParameter("@idPaciente", entity.IdPaciente));

                await command.ExecuteNonQueryAsync();

                _logger.LogInformation("Registro de inserción en DetalleAlergia con IDAlergia:{@idAlergia} y IDPaciente:{@idPaciente}", entity.IdAlergia, entity.IdPaciente);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Excepción al intentar crear un registro en DetalleAlergia");
                throw;
            }
        }

    }
}
