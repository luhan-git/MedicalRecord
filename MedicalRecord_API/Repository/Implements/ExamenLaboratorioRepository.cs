using MedicalRecord_API.Models;
using MedicalRecord_API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Data;


namespace MedicalRecord_API.Repository.Implements
{
    public class ExamenLaboratorioRepository: GenericRepository<ExamenLaboratorioRepository>, IExamenLaboratorio
    {
        private readonly DbhistoriasContext _context;
        private readonly ILogger<ExamenLaboratorioRepository> _logger;

        public ExamenLaboratorioRepository(DbhistoriasContext context, ILogger<ExamenLaboratorioRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<int> Create(Examenlaboratorio entity)
        {
            try
            {
                await using var connection = _context.Database.GetDbConnection();
                await connection.OpenAsync();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "InsertExamenLaboratorio_sp";
                command.Parameters.Add(new MySqlParameter("@p_nombre_examen", entity.Nombre));
                command.Parameters.Add(new MySqlParameter("@p_detalle_examen", entity.Abreviatura));

                var idExamenLaboratorioParam = new MySqlParameter("@p_id_ExamenLaboratorio", MySqlDbType.Int32)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(idExamenLaboratorioParam);

                await command.ExecuteNonQueryAsync();

                var idExamenLaboratorio = (int)idExamenLaboratorioParam.Value;
                if (idExamenLaboratorio == -1)
                {
                    throw new Exception("El procedimiento almacenado InsertExamenLaboratorio_sp devolvió -1, indicando un error.");
                }

                _logger.LogInformation("Registro de inserción en ExamenLaboratorio con ID:{@p_id_ExamenLaboratorio}", idExamenLaboratorio);
                
                return idExamenLaboratorio;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Excepción al intentar crear un registro en ExamenLaboratorio");
                throw;
            }
        }

        public async Task Update(Examenlaboratorio entity)
        {
            try
            {
                await using var connection = _context.Database.GetDbConnection();
                await connection.OpenAsync();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UpdateExamenLaboratorio_sp";
                command.Parameters.Add(new MySqlParameter("@p_id_examen", entity.Id));
                command.Parameters.Add(new MySqlParameter("@p_nombre_examen", entity.Nombre));
                command.Parameters.Add(new MySqlParameter("@p_detalle_examen", entity.Abreviatura));

                await command.ExecuteNonQueryAsync();

                _logger.LogInformation("Registro de actualización en ExamenLaboratorio con ID:{@");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Excepción al intentar actualizar un registro en ExamenLaboratorio");
                throw;
            }
        }
    }
}
