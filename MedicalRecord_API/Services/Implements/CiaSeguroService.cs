using MedicalRecord_API.Models;
using MedicalRecord_API.Repository.Interfaces;
using MedicalRecord_API.Services.Interfaces;
using System.Linq.Expressions;

namespace MedicalRecord_API.Services.Implements
{
    public class CiaSeguroService : ICiaSeguroService
    {
        private readonly ICiaSeguroRepository _repository;
        public CiaSeguroService(ICiaSeguroRepository repository)
        {
            _repository = repository;
        }
        public async Task<Ciaseguro> Create(Ciaseguro entity)
        {
            Ciaseguro seguro= await _repository.Create(entity);
            return seguro;
        }

        public async Task Delete(Ciaseguro seguro)
        {
            await _repository.Delete(seguro);
        }

        public async Task<Ciaseguro> GetAsync(Expression<Func<Ciaseguro, bool>> filters, bool tracked = true)
        {
           Ciaseguro ciaseguro= await _repository.GetAsync(filters, tracked);
            return ciaseguro;
        }

        public async Task<IEnumerable<Ciaseguro>> QueryAsync(Expression<Func<Ciaseguro, bool>>? filter = null, params Expression<Func<Ciaseguro, object>>[] Includes)
        {
            IEnumerable<Ciaseguro> query=await _repository.QueryAsync(filter, Includes);
            return query;
        }

        public async Task Update(Ciaseguro entity)
        {
            await _repository.Update(entity);
        }
    }
}
