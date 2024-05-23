using MedicalRecord_API.Models;
using MedicalRecord_API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Data;

namespace MedicalRecord_API.Repository.Implements
{
    public class PacienteRepository : GenericRepository<Paciente>, IPacienteRepository
    {
        private readonly DbhistoriasContext _context;
        private readonly ILogger<PacienteRepository> _logger;

        public PacienteRepository(DbhistoriasContext context, ILogger<PacienteRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Paciente> Create(Paciente entity)
        {
            try
            {
                await using var connection = _context.Database.GetDbConnection();
                await connection.OpenAsync();

                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertPaciente_sp";
                cmd.Parameters.Add(new MySqlParameter("@condicion", entity.Condicion));
                cmd.Parameters.Add(new MySqlParameter("@apaterno", entity.APaterno));
                cmd.Parameters.Add(new MySqlParameter("@amaterno", entity.AMaterno));
                cmd.Parameters.Add(new MySqlParameter("@nombres", entity.Nombres));
                cmd.Parameters.Add(new MySqlParameter("@tipoDocumento", entity.TipoDocumento));
                cmd.Parameters.Add(new MySqlParameter("@numeroDocumento", entity.NumeroDocumento));
                cmd.Parameters.Add(new MySqlParameter("@fechaNacimiento", entity.FechaNacimiento));
                cmd.Parameters.Add(new MySqlParameter("@edad", entity.Edad));
                cmd.Parameters.Add(new MySqlParameter("@sexo", entity.Sexo));
                cmd.Parameters.Add(new MySqlParameter("@estadoCivil", entity.EstadoCivil));
                cmd.Parameters.Add(new MySqlParameter("@grupoSanguineo", entity.GrupoSanguineo));
                cmd.Parameters.Add(new MySqlParameter("@nacionalidad", entity.Nacionalidad));
                cmd.Parameters.Add(new MySqlParameter("@idDepartamento", entity.IdDepartamento));
                cmd.Parameters.Add(new MySqlParameter("@idProvincia", entity.IdProvincia));
                cmd.Parameters.Add(new MySqlParameter("@idDistrito", entity.IdDistrito));
                cmd.Parameters.Add(new MySqlParameter("@direccion", entity.Direccion));
                cmd.Parameters.Add(new MySqlParameter("@telefono", entity.Telefono));
                cmd.Parameters.Add(new MySqlParameter("@celular", entity.Celular));
                cmd.Parameters.Add(new MySqlParameter("@centroTrabajo", entity.CentroTrabajo));
                cmd.Parameters.Add(new MySqlParameter("@asegurado", entity.Asegurado));
                cmd.Parameters.Add(new MySqlParameter("@idCiaSeguro", entity.IdCiaSeguro != 0 ? entity.IdCiaSeguro : (object)DBNull.Value));
                cmd.Parameters.Add(new MySqlParameter("@numeroCarnet", entity.NumeroCarnet));
                cmd.Parameters.Add(new MySqlParameter("@contacto", entity.Contacto));
                cmd.Parameters.Add(new MySqlParameter("@idParentesco", entity.IdParentesco !=0 ? entity.IdParentesco : (object)DBNull.Value));
                cmd.Parameters.Add(new MySqlParameter("@telefonoContacto", entity.TelefonoContacto));
                cmd.Parameters.Add(new MySqlParameter("@celularContacto", entity.CelularContacto));
                cmd.Parameters.Add(new MySqlParameter("@perfil", entity.Perfil));
                cmd.Parameters.Add(new MySqlParameter("@antecedentesClinicos", entity.AntecedentesClinicos));
                cmd.Parameters.Add(new MySqlParameter("@antecedentesFamiliares", entity.AntecedentesFamiliares));
                cmd.Parameters.Add(new MySqlParameter("@idOcupacion", entity.IdOcupacion));
                cmd.Parameters.Add(new MySqlParameter("@presionArterial", entity.PresionArterial));
                cmd.Parameters.Add(new MySqlParameter("@campoVisual", entity.CampoVisual));
                cmd.Parameters.Add(new MySqlParameter("@email", entity.Email));
                cmd.Parameters.Add(new MySqlParameter("@diabetico", entity.Diabetico));
                cmd.Parameters.Add(new MySqlParameter("@idDiabetes", entity.IdDiabetes != 0 ? entity.IdDiabetes : (object)DBNull.Value));
                cmd.Parameters.Add(new MySqlParameter("@alergico", entity.Alergico));

                var idPacienteParam = new MySqlParameter("@id", MySqlDbType.Int32)
                {
                    Direction = ParameterDirection.Output
                };

                cmd.Parameters.Add(idPacienteParam);

                await cmd.ExecuteNonQueryAsync();

                var idPaciente = (int)idPacienteParam.Value;

                if (idPaciente == -1)
                {
                    throw new Exception("El procedimiento almacenado InsertPaciente_sp devolvió -1, indicando un error.");
                }

                _logger.LogInformation("Registro de inserción en Paciente con ID:{@id}", idPaciente);

                return await _context.Set<Paciente>().FirstOrDefaultAsync(p => p.Id == idPaciente) ?? new();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Excepción al intentar crear un registro en Paciente");
                throw;
            }

        }

        public async Task Update(Paciente entity)
        {

        }
    }
}
