using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalRecord_API.Models;
using MedicalRecord_API.Repository.Interfaces;

namespace MedicalRecord_API.Repository.Implements
{
    public class LaboratorioRepository : GenericRepository<Laboratorio>, ILaboratorioRepository
    {
        private readonly DbhistoriasContext _context;
        public LaboratorioRepository(DbhistoriasContext context):base(context)
        {
            _context=context;
        }
        public Task<Laboratorio> Create(Laboratorio entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Laboratorio entity)
        {
            throw new NotImplementedException();
        }
    }
}