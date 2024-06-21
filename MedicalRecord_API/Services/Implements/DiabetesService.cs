//using MedicalRecord_API.Models;
//using MedicalRecord_API.Repository.Interfaces;
//using MedicalRecord_API.Services.Interfaces;
//using System.Linq.Expressions;

//namespace MedicalRecord_API.Services.Implements
//{
//    public class DiabetesService : IDiabetesService
//    {
//        private readonly IDiabetesRepository _repo;
//        public DiabetesService(IDiabetesRepository repo)
//        {
//            _repo = repo;

//        }
//        public async Task<Diabete> Create(Diabete entity)
//        {
//            entity = await _repo.Create(entity);
//            return entity;
//        }

//        public async Task Delete(Diabete entity)
//        {
//            await _repo.Delete(entity);
//        }

//        public async Task<Diabete> GetAsync(Expression<Func<Diabete, bool>> filters, bool tracked = true)
//        {
//            Diabete diabetes = await _repo.GetAsync(filters, tracked);
//            return diabetes;
//        }

//        public async Task<IEnumerable<Diabete>> QueryAsync(Expression<Func<Diabete, bool>>? filter = null, params Expression<Func<Diabete, object>>[] Includes)
//        {
//            IEnumerable<Diabete> query = await _repo.QueryAsync(filter, Includes);
//            return query;
//        }

//        public async Task Update(Diabete entity)
//        {
//            await _repo.Update(entity);
//        }
//    }
//}
