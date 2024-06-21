//using MedicalRecord_API.Models;
//using MedicalRecord_API.Repository.Interfaces;
//using Microsoft.EntityFrameworkCore;
//using MySqlConnector;
//using System.Data;

//namespace MedicalRecord_API.Repository.Implements
//{
//    public class ProcedimientoRepository : GenericRepository<Procedimiento>, IProcedimientoRepository
//    {
//        private readonly DbhistoriasContext _context;
//        private readonly ILogger<ProcedimientoRepository> _logger;

//        public ProcedimientoRepository(DbhistoriasContext context, ILogger<ProcedimientoRepository> logger) : base(context)
//        {
//            _context = context;
//            _logger = logger;
//        }

//        public async Task<Procedimiento> Create(Procedimiento entity)
//        {
//            try
//            {
//                await using var connection = _context.Database.GetDbConnection();
//                await connection.OpenAsync();

//                using var command = connection.CreateCommand();
//                command.CommandType = CommandType.StoredProcedure;
//                command.CommandText = "InsertProcedimiento_sp";
//                command.Parameters.Add(new MySqlParameter("@nombre", entity.Nombre));
//                command.Parameters.Add(new MySqlParameter("@abreviatura", entity.Abreviatura));

//                var idProcedimientoParam = new MySqlParameter("@id", MySqlDbType.Int32)
//                {
//                    Direction = ParameterDirection.Output
//                };
//                command.Parameters.Add(idProcedimientoParam);

//                await command.ExecuteNonQueryAsync();

//                var idProcedimiento = (int)idProcedimientoParam.Value;
//                if (idProcedimiento == -1)
//                {
//                    throw new Exception("El procedimiento almacenado InsertProcedimiento_sp devolvió -1, indicando un error.");
//                }

//                _logger.LogInformation("Registro en procedimiento con id: {@id}", idProcedimiento);

//                return await _context.Set<Procedimiento>().FirstOrDefaultAsync(c => c.Id == idProcedimiento) ?? new();
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "Error en create procedimiento");
//                throw;
//            }
//        }

//        public async Task Update(Procedimiento entity)
//        {
//            try
//            {
//                await using var connection = _context.Database.GetDbConnection();
//                await connection.OpenAsync();

//                using var command = connection.CreateCommand();
//                command.CommandType = CommandType.StoredProcedure;
//                command.CommandText = "UpdateProcedimiento_sp";
//                command.Parameters.Add(new MySqlParameter("@idUpdate", entity.Id));
//                command.Parameters.Add(new MySqlParameter("@nombre", entity.Nombre));
//                command.Parameters.Add(new MySqlParameter("@abreviatura", entity.Abreviatura));

//                await command.ExecuteNonQueryAsync();

//                _logger.LogInformation("Actualización en procedimiento con id: {@id}", entity.Id);
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "Error en update procedimiento");
//                throw;
//            }
//        }
//    }
//}
