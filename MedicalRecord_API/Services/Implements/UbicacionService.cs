using MedicalRecord_API.Models;
using MedicalRecord_API.Repository;
using MedicalRecord_API.Services.Interfaces;

namespace MedicalRecord_API.Services.Implements
{
    public class UbicacionService : IUbicacionService
    {
        private readonly IGenericRepository<Departamento> _dep;
        private readonly IGenericRepository<Provincia> _prov;
        private readonly IGenericRepository<Distrito> _dist;
        public UbicacionService(IGenericRepository<Departamento>dep,IGenericRepository<Provincia> prov, IGenericRepository<Distrito> dist)
        {
            _prov = prov;
            _dep = dep;
            _dist = dist;
        }
        public async Task<IEnumerable<Departamento>> Departamentos()
        {
            IEnumerable<Departamento> departamentos = await _dep.QueryAsync();
            return departamentos;
        }

        public async Task<IEnumerable<Distrito>> Distritos(int id)
        {
           IEnumerable<Distrito>distritos=await _dist.QueryAsync(x=>x.IdProvincia==id);
            return distritos;
        }

        public async Task<IEnumerable<Provincia>> Provincias(int id)
        {
            IEnumerable<Provincia> provincias = await _prov.QueryAsync(p=> p.IdDepartamento==id);
            return provincias;
        }
    }
}
