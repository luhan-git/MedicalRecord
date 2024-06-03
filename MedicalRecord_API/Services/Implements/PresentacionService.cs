using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MedicalRecord_API.Models;
using MedicalRecord_API.Repository.Interfaces;
using MedicalRecord_API.Services.Interfaces;

namespace MedicalRecord_API.Services.Implements
{
    public class PresentacionService : IPresentacionService
    {
        private readonly IPresentacionRepository _repo;
        public PresentacionService(IPresentacionRepository repo)
        {
            _repo=repo;
        }
        public async Task<Presentacion> Create(Presentacion presentacion)
        {
            
            await _repo.Create(presentacion);
            return presentacion;
          
        }

        public async  Task<Presentacion> GetAsync(Expression<Func<Presentacion, bool>> filters, bool tracked = true)
        {
            Presentacion presentacion=await _repo.GetAsync(filters,tracked);
            return presentacion;
            
        }

        public async Task<List<Presentacion>> QueryAsync(Expression<Func<Presentacion, bool>>? filter = null, params Expression<Func<Presentacion, object>>[] includes)
        {
            IEnumerable<Presentacion> presentacionList= await _repo.QueryAsync(filter,includes);
            return presentacionList.ToList();
        }

        public async Task Update(Presentacion presentacion)
        {
            await _repo.Update(presentacion);
        }
    }
}