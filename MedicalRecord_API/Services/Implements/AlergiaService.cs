//using MedicalRecord_API.Models;
//using MedicalRecord_API.Repository.Interfaces;
//using MedicalRecord_API.Services.Interfaces;
//using System.Linq.Expressions;

//namespace MedicalRecord_API.Services.Implements
//{
//    public class AlergiaService : IAlergiaService
//    {
//        private readonly IAlergiaRepository _repo;
//        public AlergiaService(IAlergiaRepository repo)
//        {
//            _repo = repo;
//        }
//        public async Task<Alergium> Create(Alergium entity)
//        {
//            Alergium alergia = await _repo.Create(entity);
//            return alergia;
//        }

//        public async Task Delete(Alergium alergia)
//        {
//            await _repo.Delete(alergia);
//        }

//        public async Task<Alergium> GetAsync(Expression<Func<Alergium, bool>> filters, bool tracked = true)
//        {
//            Alergium alergia = await _repo.GetAsync(filters, tracked);
//            return alergia;
//        }

//        public async Task<IEnumerable<Alergium>> QueryAsync(Expression<Func<Alergium, bool>>? filter = null, params Expression<Func<Alergium, object>>[] Includes)
//        {
//            IEnumerable<Alergium> alergias = await _repo.QueryAsync(filter, Includes);
//            return alergias.ToList();
//        }

//        public async Task Update(Alergium entity)
//        {
//            await _repo.Update(entity);
//        }
//    }
//}
