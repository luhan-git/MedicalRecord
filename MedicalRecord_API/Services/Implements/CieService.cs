//using MedicalRecord_API.Models;
//using MedicalRecord_API.Repository.Interfaces;
//using MedicalRecord_API.Services.Interfaces;
//using System.Linq.Expressions;

//namespace MedicalRecord_API.Services.Implements
//{
//    public class CieService : ICieService
//    {
//        private readonly ICieRepository _repo;
//        public CieService(ICieRepository repo)
//        {
//            _repo = repo;
//        }
//        public async Task<Cie> Create(Cie cie)
//        {
//            cie = await _repo.Create(cie);
//            return cie;
//        }

//        public async Task Delete(Cie cie)
//        {
//            await _repo.Delete(cie);
//        }

//        public async Task<Cie> GetAsync(Expression<Func<Cie, bool>> filters, bool tracked = true)
//        {
//            Cie cie = await _repo.GetAsync(filters, tracked);
//            return cie;
//        }

//        public async Task<IEnumerable<Cie>> QueryAsync(Expression<Func<Cie, bool>>? filter = null, params Expression<Func<Cie, object>>[] Includes)
//        {
//            IEnumerable<Cie> query = await _repo.QueryAsync(filter, Includes);
//            return query;
//        }

//        public async Task Update(Cie cie)
//        {
//            await _repo.Update(cie);
//        }
//    }
//}
