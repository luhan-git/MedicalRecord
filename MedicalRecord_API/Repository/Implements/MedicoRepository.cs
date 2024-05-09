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
            try
            {

            await using var connection = _context.Database.GetDbConnection();
            await connection.OpenAsync();

            var command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_crearmedico";

            command.Parameters.Add(new MySqlParameter("@nombre_med", entity.NombreMed));
            command.Parameters.Add(new MySqlParameter("@espe_med", entity.EspeMed));
            command.Parameters.Add(new MySqlParameter("@nro_cmed", entity.NroCmed));

            var idMedicoParam = new MySqlParameter("@id_medico", MySqlDbType.Int32)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(idMedicoParam);
            await command.ExecuteNonQueryAsync();
            // Obtener el valor del parámetro de salida
            var idMedico = (int)idMedicoParam.Value;

            // Verificar si el procedimiento almacenado devolvió -1
            if (idMedico == -1)
            {
                throw new Exception("El procedimiento almacenado devolvió -1, indicando un error.");
            }

                return idMedico;
            }
            catch
            {
                throw;
            }

        }


        public Task<Medico> Update(Medico entity)
        {
            throw new NotImplementedException();
        }
    }
}
