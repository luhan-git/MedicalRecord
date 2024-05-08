using MedicalRecord_API.Models;
using MedicalRecord_API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace MedicalRecord_API.Repository.Implements
{
    public class MedicoRepository : GenericRepository<Medico>, IMedicoRepository
    {
        private readonly DbhistoriasContext _context;

        public MedicoRepository(DbhistoriasContext context):base(context)
        {
            _context = context;

        }
        public async Task<int> Create(Medico entity)
        {
            var idMedicoParam = new MySqlParameter("@id_medico", MySqlDbType.Int32)
            {
                Direction = ParameterDirection.Output
            };
            string sql = "CALL sp_crearmedico(nombre_med,espe_med,nro_cmed)";
            await _context.Database.ExecuteSqlRawAsync(sql,
            new MySqlParameter("@nombre_med", entity.NombreMed),
            new MySqlParameter("@espe_med", entity.EspeMed),
            new MySqlParameter("@nro_cmed", entity.NroCmed),
            idMedicoParam
                );
            return (int)idMedicoParam.Value;
        }
        public Task<Medico> Update(Medico entity)
        {
            throw new NotImplementedException();
        }
    }
}
