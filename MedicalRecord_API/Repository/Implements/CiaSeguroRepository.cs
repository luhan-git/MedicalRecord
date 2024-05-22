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

        public async Task<Ciaseguro> Create(Ciaseguro entity)
        {
            try
            {
                await using var connection = _context.Database.GetDbConnection();
                await connection.OpenAsync();

                using var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "InsertCiaSeguro_sp";
                command.Parameters.Add(new MySqlParameter("@nombre", entity.Nombre));
                command.Parameters.Add(new MySqlParameter("@abreviatura", entity.Abreviatura));

                var idCiaSeguroParam = new MySqlParameter("@id", MySqlDbType.Int32)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(idCiaSeguroParam);

                await command.ExecuteNonQueryAsync();

                var idCiaSeguro = (int)idCiaSeguroParam.Value;
                if (idCiaSeguro == -1)
                {
                    throw new Exception("El procedimiento almacenado InsertCiaSeguro_sp devolvió -1, indicando un error.");
                }

                _logger.LogInformation("Registro de inserción en CiaSeguro con ID:{@id}", idCiaSeguro);

                return await _context.Set<Ciaseguro>().FirstOrDefaultAsync(c => c.Id == idCiaSeguro) ?? new();
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

                using var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UpdateCiaSeguro_sp";
                command.Parameters.Add(new MySqlParameter("@idUpdate", entity.Id));
                command.Parameters.Add(new MySqlParameter("@nombre", entity.Nombre));
                command.Parameters.Add(new MySqlParameter("@abreviatura", entity.Abreviatura));

                await command.ExecuteNonQueryAsync();

                _logger.LogInformation("Registro de actualización en CiaSeguro con ID:{@idUpdate}", entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Excepción al intentar actualizar un registro en CiaSeguro");
                throw;
            }
        }

    }
}
