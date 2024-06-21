//using MedicalRecord_API.Models;
//using MedicalRecord_API.Repository.Interfaces;

//namespace MedicalRecord_API.Repository.Implements
//{
//    public class MedicamentoRepository : GenericRepository<Medicamento>, IMedicamentoRepository
//    {
//        private readonly DbhistoriasContext _context;
//        private readonly ILogger<PacienteRepository> _logger;

//        public MedicamentoRepository(DbhistoriasContext context, ILogger<PacienteRepository> logger) : base(context)
//        {
//            _context = context;
//            _logger = logger;
//        }

//        public async Task<Medicamento> Create(Medicamento entity)
//        {
//            Medicamento medicamento;
//            try
//            {
//                await _context.AddAsync(entity);
//                await _context.SaveChangesAsync();
//                medicamento = entity;
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "Error en create medicamento");
//                throw;
//            }
//            return medicamento;
//        }

//        public async Task Update(Medicamento entity)
//        {
//            try
//            {
//                _context.Update(entity);
//                await _context.SaveChangesAsync();
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "Error en update medicamento");
//                throw;
//            }
//        }
//    }
//}
