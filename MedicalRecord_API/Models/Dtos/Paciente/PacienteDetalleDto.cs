
namespace MedicalRecord_API.Models.Dtos.Paciente
{
    public class PacienteDetalleDto
    {
        public int Id { get; set; }

        public string Condicion { get; set; } = null!;

        public string PrimerNombre { get; set; } = null!;

        public string? SegundoNombre { get; set; }

        public string APaterno { get; set; } = null!;

        public string AMaterno { get; set; } = null!;

        public string TipoDocumento { get; set; } = null!;

        public string NumeroDocumento { get; set; } = null!;

        public DateTime FechaNacimiento { get; set; }

        public string Edad { get; set; } = null!;

        public string Sexo { get; set; } = null!;

        public string EstadoCivil { get; set; } = null!;

        public string GrupoSanguineo { get; set; } = null!;

        public string Nacionalidad { get; set; } = null!;

        public int IdDepartamento { get; set; }

        public int IdProvincia { get; set; }

        public int IdDistrito { get; set; }

        public string? Direccion { get; set; }

        public string? Telefono { get; set; }

        public string? Celular { get; set; }

        public string? Email { get; set; }

        public int IdOcupacion { get; set; }

        public string? CentroTrabajo { get; set; }

        public bool? IsAsegurado { get; set; }

        public int? IdSeguro { get; set; }

        public string? NumeroCarnet { get; set; }

        public string? Perfil { get; set; }

        public bool? IsAlergico { get; set; }

        public bool? IsDiabetico { get; set; }

        public bool? IsDelete { get; set; }

    }
}
