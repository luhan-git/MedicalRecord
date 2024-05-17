using MedicalRecord_API.Models;
using MedicalRecord_API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Data;

namespace MedicalRecord_API.Repository.Implements
{
    public class DirectorioRepository : GenericRepository<Directorio>, IDirectorioRepository
    {
        private readonly DbhistoriasContext _context;
        private readonly ILogger<DirectorioRepository> _logger;

        public DirectorioRepository(DbhistoriasContext context, ILogger<DirectorioRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<int> Create(Directorio entity)
        {
            try
            {
                await using var connection = _context.Database.GetDbConnection();
                await connection.OpenAsync();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "InsertDirectorio_sp";
                command.Parameters.Add(new MySqlParameter("@p_nombre", entity.Nombre));
                command.Parameters.Add(new MySqlParameter("@p_repre", entity.Representante));
                command.Parameters.Add(new MySqlParameter("@p_fono", entity.Telefono));
                command.Parameters.Add(new MySqlParameter("@p_celular", entity.Celular));
                command.Parameters.Add(new MySqlParameter("@p_email", entity.Email));
                command.Parameters.Add(new MySqlParameter("@p_direccion", entity.Direccion));
                command.Parameters.Add(new MySqlParameter("@p_estado", entity.Estado));

                var idDirectorioParam = new MySqlParameter("@p_id_directorio", MySqlDbType.Int32)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(idDirectorioParam);

                await command.ExecuteNonQueryAsync();

                var idDirectorio = (int)idDirectorioParam.Value;
                if (idDirectorio == -1)
                {
                    throw new Exception("El procedimiento almacenado InsertDirectorio_sp devolvió -1, indicando un error.");
                }

                _logger.LogInformation("Registro de inserción en Directorio con ID:{@p_id_directorio}", idDirectorio);
                
                return idDirectorio;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Excepción al intentar crear un registro en Directorio");
                throw;
            }
        }

        public async Task Update(Directorio entity)
        {
            try
            {
                await using var connection = _context.Database.GetDbConnection();
                await connection.OpenAsync();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UpdateDirectorio_sp";
                command.Parameters.Add(new MySqlParameter("@p_id_directorio", entity.Id));
                command.Parameters.Add(new MySqlParameter("@p_nombre", entity.Nombre));
                command.Parameters.Add(new MySqlParameter("@p_repre", entity.Representante));
                command.Parameters.Add(new MySqlParameter("@p_fono", entity.Telefono));
                command.Parameters.Add(new MySqlParameter("@p_celular", entity.Celular));
                command.Parameters.Add(new MySqlParameter("@p_email", entity.Email));
                command.Parameters.Add(new MySqlParameter("@p_direccion", entity.Direccion));
                command.Parameters.Add(new MySqlParameter("@p_estado", entity.Estado));

                await command.ExecuteNonQueryAsync();

                _logger.LogInformation("Registro de actualización en Directorio con ID:{@p_id_directorio}", entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Excepción al intentar actualizar un registro en Directorio");
                throw;
            }
        }
    }
}
