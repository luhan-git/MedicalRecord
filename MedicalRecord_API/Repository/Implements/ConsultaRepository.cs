//using MedicalRecord_API.Models;
//using MedicalRecord_API.Repository.Interfaces;
//using Microsoft.EntityFrameworkCore;
//using MySqlConnector;
//using System.Data;

//namespace MedicalRecord_API.Repository.Implements
//{
//    public class ConsultaRepository : GenericRepository<Consultum>, IConsultaRepository
//    {
//        private readonly DbhistoriasContext _context;
//        private readonly ILogger<ConsultaRepository> _logger;

//        public ConsultaRepository(DbhistoriasContext context, ILogger<ConsultaRepository> logger) : base(context)
//        {
//            _context = context;
//            _logger = logger;
//        }

//        public async Task<Consultum> Create(Consultum entity)
//        {
//            try
//            {
//                await using var connection = _context.Database.GetDbConnection();
//                await connection.OpenAsync();

//                using var command = connection.CreateCommand();
//                command.CommandType = CommandType.StoredProcedure;
//                command.CommandText = "InsertConsulta_sp";
//                command.Parameters.Add(new MySqlParameter("@idPaciente", entity.IdPaciente));
//                command.Parameters.Add(new MySqlParameter("@numeroConsulta", entity.NumeroConsulta));
//                command.Parameters.Add(new MySqlParameter("@motivo", entity.Motivo));
//                command.Parameters.Add(new MySqlParameter("@enfermedadActual", entity.EnfermedadActual));
//                command.Parameters.Add(new MySqlParameter("@davsc", entity.Davsc));
//                command.Parameters.Add(new MySqlParameter("@iavsc", entity.Iavsc));
//                command.Parameters.Add(new MySqlParameter("@davcc", entity.Davcc));
//                command.Parameters.Add(new MySqlParameter("@iavcc", entity.Iavcc));
//                command.Parameters.Add(new MySqlParameter("@dpio", entity.Dpio));
//                command.Parameters.Add(new MySqlParameter("@ipio", entity.Ipio));
//                command.Parameters.Add(new MySqlParameter("@shimer", entity.Shimer));
//                command.Parameters.Add(new MySqlParameter("@valorK", entity.ValorK));
//                command.Parameters.Add(new MySqlParameter("@diagnostico", entity.Diagnostico));
//                command.Parameters.Add(new MySqlParameter("@idCie", entity.IdCie));
//                command.Parameters.Add(new MySqlParameter("@idUsuario", entity.IdUsuario));

//                var idConsultaParam = new MySqlParameter("@id", MySqlDbType.Int32)
//                {
//                    Direction = ParameterDirection.Output
//                };
//                command.Parameters.Add(idConsultaParam);

//                await command.ExecuteNonQueryAsync();

//                var idConsulta = (int)idConsultaParam.Value;

//                if (idConsulta == -1)
//                {
//                    throw new Exception("El procedimiento almacenado InsertConsulta_sp devolvió -1, indicando un error.");
//                }

//                _logger.LogInformation("Registro en consulta con id: {@id}", idConsulta);

//                return await _context.Set<Consultum>().FirstOrDefaultAsync(c => c.Id == idConsulta) ?? new();
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "Error en create consulta");
//                throw;
//            }
//        }
//    }
//}
