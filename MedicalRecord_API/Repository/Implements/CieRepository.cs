using MedicalRecord_API.Models;
using MedicalRecord_API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Data;
using System.Runtime.CompilerServices;

namespace MedicalRecord_API.Repository.Implements
{
    public class CieRepository : GenericRepository<Cie>, ICieRepository
    {
        private readonly DbhistoriasContext _context;
        private readonly ILogger<OcupacionRepository> _logger;

        public CieRepository(DbhistoriasContext context, ILogger<OcupacionRepository> logger):base(context)
        {
            _context = context;
            _logger=logger;
        }
        public async Task<int> Create(Cie entity)
        {
            try
            {
                await using var connection = _context.Database.GetDbConnection();
                await connection.OpenAsync();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "InsertCie";

                command.Parameters.Add(new MySqlParameter("@codcie", entity.Codigo));
                command.Parameters.Add(new MySqlParameter("@enfermedad", entity.Enfermedad));

                var idCieParam = new MySqlParameter("@id_cie", MySqlDbType.Int32)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(idCieParam);

                await command.ExecuteNonQueryAsync();

                var idCie = (int)idCieParam.Value;
                if (idCie == -1)
                {
                    throw new Exception("El procedimiento almacenado InsertCie devolvió -1, indicando un error.");
                }
                _logger.LogInformation("Registro de inserción en Cie con ID: {idCie}", idCie);
                return idCie;
            }
            catch (Exception ex)
            {
                {
                    _logger.LogError(ex, "Error al intentar crear un Cie");
                    throw;
                }

            }
        }

        public async Task Update(Cie entity)
        {
            try
            {

                string sql = "CALL UpdateCie (@id_cie_update, @codcie,@enfermedad)";
                await _context.Database.ExecuteSqlRawAsync(sql,
                    new MySqlParameter("@id_cie_update", entity.Codigo),
                    new MySqlParameter("@codcie", entity.Codigo),
                    new MySqlParameter("@enfermedad", entity.Enfermedad)
               
                    );
                _logger.LogInformation("Se actualizó un cie con ID: {idCie}", entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al intentar actualizar un cie");
                throw;
            }
        }
    }
}
