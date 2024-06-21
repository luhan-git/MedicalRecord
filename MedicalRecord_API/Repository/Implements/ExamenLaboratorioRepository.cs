//using MedicalRecord_API.Models;
//using MedicalRecord_API.Repository.Interfaces;

//namespace MedicalRecord_API.Repository.Implements
//{
//    public class ExamenLaboratorioRepository : GenericRepository<Examenlaboratorio>, IExamenLaboratorioRepository
//    {
//        private readonly DbhistoriasContext _context;
//        private readonly ILogger<ExamenLaboratorioRepository> _logger;

//        public ExamenLaboratorioRepository(DbhistoriasContext context, ILogger<ExamenLaboratorioRepository> logger) : base(context)
//        {
//            _context = context;
//            _logger = logger;
//        }

//        public Task<Examenlaboratorio> Create(Examenlaboratorio entity)
//        {
//            throw new NotImplementedException();
//        }

//        public Task Update(Examenlaboratorio entity)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
