using MedicalRecord_API.Models;
using MedicalRecord_API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
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
                var nombreParam = new MySqlParameter("@nombre", entity.Nombre);
                var correoParam = new MySqlParameter("@correo", entity.Correo);
                var claveParam = new MySqlParameter("@clave", entity.Clave);
                var cargoParam = new MySqlParameter("@cargo", entity.Cargo);
                var especialidadParam = new MySqlParameter("@especialidad", entity.Especialidad);
                var nroColMedicoParam = new MySqlParameter("@nroColMedico", entity.NroColMedico);
            try
            {
                await _context.Database.ExecuteSqlRawAsync("CALL sp_InsertUsuario(@nombre, @correo, @clave, @cargo, @especialidad, @nroColMedico)",
                                                           nombreParam, correoParam, claveParam, cargoParam, especialidadParam, nroColMedicoParam);
                 return  await _context.Set<Usuario>().FirstOrDefaultAsync(u => u.Correo == entity.Correo);
            }
            catch (Exception)
            {
                _logger.LogError("Error creating user");
                throw;
            }
        }

        public async Task Update(Usuario entity)
        {
            var idParam = new MySqlParameter("@id_update",entity.Id);
            var nombreParam = new MySqlParameter("@nombre", entity.Nombre);
            var correoParam = new MySqlParameter("@correo", entity.Correo);
            var claveParam = new MySqlParameter("@clave", entity.Clave);
            var cargoParam = new MySqlParameter("@cargo", entity.Cargo);
            var especialidadParam = new MySqlParameter("@especialidad", entity.Especialidad);
            var nroColMedicoParam = new MySqlParameter("@nroColMedico", entity.NroColMedico);
            try
            {
                await _context.Database.ExecuteSqlRawAsync("CALL sp_UpdateUsuario(@idUpdate,@nombre, @correo, @clave, @cargo, @especialidad, @nroColMedico)",
                                                          idParam, nombreParam, correoParam, claveParam, cargoParam, especialidadParam, nroColMedicoParam);
            }
            catch (Exception)
            {
                _logger.LogError("Error updting user");
                throw;
            }
        }
    }
}
