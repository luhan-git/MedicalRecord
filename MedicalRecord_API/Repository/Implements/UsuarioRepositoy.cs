using MedicalRecord_API.Models;
using MedicalRecord_API.Repository.Interfaces;
using MedicalRecord_API.Utils.Recursos.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using MySqlConnector;
using System.Data;

namespace MedicalRecord_API.Repository.Implements
{
    public class UsuarioRepositoy : GenericRepository<Usuario>, IUsuarioRepository
    {
        private readonly DbhistoriasContext _context;
        private readonly ILogger<UsuarioRepositoy> _logger;
        public UsuarioRepositoy(DbhistoriasContext context, ILogger<UsuarioRepositoy> logger) : base(context)
        {

            _context = context;
            _logger = logger;
        }

        public async Task<Usuario> Create(Usuario entity)
        { 
            try
            {
            
                await _context.Database.ExecuteSqlRawAsync("CALL sp_InsertUsuario(@nombre, @correo, @clave, @cargo, @especialidad, @nroColMedico)",
                                                           new MySqlParameter("@nombre", entity.Nombre),
                                                           new MySqlParameter("@correo", entity.Correo),
                                                           new MySqlParameter("@clave",  entity.Clave),
                                                           new MySqlParameter("@cargo", entity.Cargo),
                                                           new MySqlParameter("@especialidad", entity.Especialidad),
                                                           new MySqlParameter("@nroColMedico", entity.NroColMedico)
                                                           );
                _logger.LogWarning("Se creo un nuevo usuario en la base de datos");
                return await _context.Set<Usuario>().FirstOrDefaultAsync(u => string.Equals(u.Correo, entity.Correo)) ?? new();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en create usuario");
                throw;
            }
        }

        public async Task Update(Usuario entity)
        {
            try
            {
                entity.Clave ??= await _context.Set<Usuario>()
                                                .Where(u => u.Id == entity.Id)
                                                .Select(u => u.Clave)
                                                .FirstOrDefaultAsync();


                await _context.Database.ExecuteSqlRawAsync("CALL sp_UpdateUsuario(@idUpdate,@nombre, @correo, @clave,@cargo, @especialidad, @nroColMedico,@activo)",
                                                           new MySqlParameter("@idUpdate", entity.Id),
                                                           new MySqlParameter("@nombre", entity.Nombre),
                                                           new MySqlParameter("@correo", entity.Correo),
                                                           new MySqlParameter("@clave", entity.Clave),
                                                           new MySqlParameter("@cargo", entity.Cargo),
                                                           new MySqlParameter("@especialidad", entity.Especialidad),
                                                           new MySqlParameter("@nroColMedico", entity.NroColMedico),
                                                           new MySqlParameter("@activo", entity.Activo)
                                                           );
                _logger.LogWarning("Se actualizó un usuario con id: {id} en la base de datos", entity.Id);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en update usuario");
                throw;
            }
        }
    }
}
