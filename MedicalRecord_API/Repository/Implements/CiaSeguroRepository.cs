using MedicalRecord_API.Models;
using MedicalRecord_API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace MedicalRecord_API.Repository.Implements
{
    public class CiaSeguroRepository : GenericRepository<Ciaseguro>, ICiaSeguroRepository
    {
        private readonly DbhistoriasContext _context;
        private readonly ILogger<CiaSeguroRepository> _logger;

        public CiaSeguroRepository(DbhistoriasContext context, ILogger<CiaSeguroRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Ciaseguro> Create(Ciaseguro entity)
        {
            try
            {

                await _context.Database.ExecuteSqlRawAsync("CALL sp_InsertCiaSeguro(@nombre,@abreviatura)",
                                                           new MySqlParameter("@nombre", entity.Nombre),
                                                           new MySqlParameter("@abreviatura", entity.Abreviatura)
                                                           );
                _logger.LogWarning("Se creo un nuevo seguro en la base de datos");
                Ciaseguro seguro = await _context.Set<Ciaseguro>().FirstOrDefaultAsync(u => string.Equals(u.Nombre, entity.Nombre)) ?? new();
                return seguro;
            }
            catch
            {
                _logger.LogError("Ocurrio un error al crear un seguro");
                throw;
            }
        }

        public async Task Update(Ciaseguro entity)
        {
            try
            {
                await _context.Database.ExecuteSqlRawAsync("CALL sp_UpdateCiaSeguro(@idUpdate,@nombre,@abreviatura)",
                                                           new MySqlParameter("@idUpdate", entity.Id),
                                                           new MySqlParameter("@nombre", entity.Nombre),
                                                           new MySqlParameter("@abreviatura", entity.Abreviatura)
                                                           );
                _logger.LogWarning("Se actualizó un seguro con id: {id} en la base de datos", entity.Id);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrio un error al actualizar un seguro");
                throw;
            }
        }

    }
}
