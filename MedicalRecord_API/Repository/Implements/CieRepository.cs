﻿using MedicalRecord_API.Models;
using MedicalRecord_API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Data;
using System.Runtime.CompilerServices;

namespace MedicalRecord_API.Repository.Implements
{
    public class CieRepository : GenericRepository<Cie>, ICieRepository
    {
        private readonly DbhistoriasContext _context;
        private readonly ILogger<OcupacionRepository> _logger;

        public CieRepository(DbhistoriasContext context, ILogger<OcupacionRepository> logger):base(context)
        {
            _context = context;
            _logger=logger;
        }
        public async Task<Cie> Create(Cie entity)
        {
            var codigoParam = new MySqlParameter("@codigo", entity.Codigo);
            var enfermedadParam = new MySqlParameter("@enfermedad", entity.Enfermedad);
        
            try
            {
                await _context.Database.ExecuteSqlRawAsync("CALL sp_InsertCie(@codigo, @enfermedad)",
                                                           new MySqlParameter("@codigo", entity.Codigo),
                                                           new MySqlParameter("@enfermedad", entity.Enfermedad));
                _logger.LogWarning("Se creo un nuevo cie con codigo : {codigo}",entity.Codigo);
                return await _context.Set<Cie>().FirstOrDefaultAsync(c => string.Equals(c.Codigo,entity.Codigo))?? new();
            }
            catch (Exception)
            {
                _logger.LogError("Error creating cie");
                throw;
            }
        }

        public async Task Update(Cie entity)
        {
            try
            {

                string sql = "CALL sp_UpdateCie (@id_update, @codigo,@enfermedad)";
                await _context.Database.ExecuteSqlRawAsync(sql,
                    new MySqlParameter("@id_update", entity.Id),
                    new MySqlParameter("@codigo", entity.Codigo),
                    new MySqlParameter("@enfermedad", entity.Enfermedad)
               
                    );
                _logger.LogWarning("Se actualizó un cie con id: {id} en la base de datos",entity.Id);
            }
            catch (Exception)
            {
                _logger.LogError("Error actualizando un cie");
                throw;
            }
        }
    }
}