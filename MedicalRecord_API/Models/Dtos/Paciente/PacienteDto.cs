using System.ComponentModel.DataAnnotations;
using MedicalRecord_API.Models.Dtos.DetalleAlergia;
using MedicalRecord_API.Models.Dtos.Consulta;
using MedicalRecord_API.Models.Dtos.CiaSeguro;
using MedicalRecord_API.Models.Dtos.Ubicacion;
using MedicalRecord_API.Models.Dtos.Diabetes;
using MedicalRecord_API.Models.Dtos.Ocupacion;
using MedicalRecord_API.Models.Dtos.Parentesco;

namespace MedicalRecord_API.Models.Dtos.Paciente
{
    public class PacienteDto
    {
        public int Id { get; set; }

        public string Condicion { get; set; } = null!;

        public string APaterno { get; set; } = null!;

        public string AMaterno { get; set; } = null!;

        public string Nombres { get; set; } = null!;

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

        public string? CentroTrabajo { get; set; }

        public bool? Asegurado { get; set; }

        public int? IdCiaSeguro { get; set; }

        public string? NumeroCarnet { get; set; }

        public string? Contacto { get; set; }

        public int? IdParentesco { get; set; }

        public string? TelefonoContacto { get; set; }

        public string? CelularContacto { get; set; }

        public string? Perfil { get; set; }

        public string? AntecedentesClinicos { get; set; }

        public string? AntecedentesFamiliares { get; set; }

        public int IdOcupacion { get; set; }

        public string PresionArterial { get; set; } = null!;

        public string? CampoVisual { get; set; }

        public string? Email { get; set; }

        public bool? Diabetico { get; set; }

        public int? IdDiabetes { get; set; }

        public bool? Alergico { get; set; }

        public DateTime? FechaActualizacion { get; set; }

        public virtual ICollection<DetalleAlergiaDto> Detallealergia { get; set; } =[];


    }
}
