using MedicalRecord_API.Models;
using MedicalRecord_API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;


namespace MedicalRecord_API.Repository.Implements
{
    public class CiaSegurosRepository: GenericRepository<CiaSeguros>, ICiaSegurosRepository
    {
        private readonly DbhistoriasContext _context;
        private readonly ILogger<CiaSegurosRepository> _logger;

        public CiaSegurosRepository(DbhistoriasContext context, ILogger<CiaSegurosRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<int> Create(CiaSeguros entity)
        {
            try
            {

                await using var connection = _context.Database.GetDbConnection();
                await connection.OpenAsync();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_crearciaseguros";

                command.Parameters.Add(new MySqlParameter("@nombre_cia", entity.NombreCia));
                command.Parameters.Add(new MySqlParameter("@direccion_cia", entity.DireccionCia));
                command.Parameters.Add(new MySqlParameter("@telefono_cia", entity.TelefonoCia));

                var idCiaSegurosParam = new MySqlParameter("@id_cia_seguros", MySqlDbType.Int32)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(idCiaSegurosParam);
                await command.ExecuteNonQueryAsync();
                var idCiaSeguros = (int)idCiaSegurosParam.Value;
                if (idCiaSeguros == -1)
                {
                    throw new Exception("El procedimiento almacenado sp_crearciaseguros devolvió -1, indicando un error.");
                }
                _logger.LogInformation("Se creo una nueva compañia de seguros con ID:{idCiaSeguros}", idCiaSeguros);
                return idCiaSeguros;
            }
            catch (Exception ex)
            {
                {
                    _logger.LogError(ex, "Error al intentar crear una compañia de seguros");
                    throw;
                }

            }
        }

        public async Task Update(CiaSeguros entity)
        {
            try
            {
                await using var connection = _context.Database.GetDbConnection();
                await connection.OpenAsync();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure
            }
        }
    }
}
