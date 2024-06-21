//using MedicalRecord_API.Models;
//using MedicalRecord_API.Repository.Interfaces;
//using Microsoft.EntityFrameworkCore;
//using MySqlConnector;

//namespace MedicalRecord_API.Repository.Implements
//{
//    public class AlergiaRepository : GenericRepository<Alergium>, IAlergiaRepository
//    {
//        private readonly DbhistoriasContext _context;
//        private readonly ILogger<AlergiaRepository> _logger;

//        public AlergiaRepository(DbhistoriasContext context, ILogger<AlergiaRepository> logger) : base(context)
//        {
//            _context = context;
//            _logger = logger;
//        }

//        public async Task<Alergium> Create(Alergium entity)
//        {
//            try
//            {

//                await _context.Database.ExecuteSqlRawAsync("CALL sp_InsertAlergia(@nombre)",
//                                                           new MySqlParameter("@nombre", entity.Nombre)
//                                                           );
//                _logger.LogWarning("Se creo una nueva en la base de datos");
//                Alergium alergia = await _context.Set<Alergium>().FirstOrDefaultAsync(u => string.Equals(u.Nombre, entity.Nombre)) ?? new();
//                return alergia;
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "Ocurrio un error al crear una alergia");
//                throw;
//            }

//        }

//        public async Task Update(Alergium entity)
//        {
//            try
//            {
//                await _context.Database.ExecuteSqlRawAsync("CALL sp_UpdateAlergia(@idUpdate,@nombre)",
//                                                           new MySqlParameter("@idUpdate", entity.Id),
//                                                           new MySqlParameter("@nombre", entity.Nombre)
//                                                           );
//                _logger.LogWarning("Se actualizó una alergia con id: {id} en la base de datos", entity.Id);

//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "Ocurrio un error al actualizar alergia");
//                throw;
//            }
//        }
//    }
//}
