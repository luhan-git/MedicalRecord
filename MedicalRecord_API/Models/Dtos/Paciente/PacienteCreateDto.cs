using System.ComponentModel.DataAnnotations;

namespace MedicalRecord_API.Models.Dtos.Paciente
{
    public class PacienteCreateDto
    {
        [Required]
        [AllowedValues("0","1","2")]
        public string Condicion { get; set; } = null!;
        [Required]
        public string PrimerNombre { get; set; } = null!;
        public string? SegundoNombre { get; set; }
        [Required]
        public string APaterno { get; set; } = null!;
        [Required]
        public string AMaterno { get; set; } = null!;
        [Required]
        [AllowedValues("0","1","2","3")]
        public string TipoDocumento { get; set; } = null!;
        [Required]
        public string NumeroDocumento { get; set; } = null!;
        [Required]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        [AllowedValues("M","F")]
        public string Sexo { get; set; } = null!;
        [Required]
        [AllowedValues("0","1","2","3","4")]
        public string EstadoCivil { get; set; } = null!;
        [Required]
        [AllowedValues("0", "1", "2", "3", "4", "5", "6", "7", "8")]
        public string GrupoSanguineo { get; set; } = null!;
        [Required]
        [AllowedValues("0", "1")]
        public string Nacionalidad { get; set; } = null!;
        [Required]
        [Range(1,26)]
        public int IdDepartamento { get; set; }
        [Required]
        [Range(1,194)]
        public int IdProvincia { get; set; }
        [Required]
        [Range(1, 1833)]
        public int IdDistrito { get; set; }
        public string? Direccion { get; set; }
        [Phone]
        public string? Telefono { get; set; }
        [Phone]
        public string? Celular { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public int IdOcupacion { get; set; }
        public string? CentroTrabajo { get; set; }
        public int? IdSeguro { get; set; }
        public string? NumeroCarnet { get; set; }
        public string? Perfil { get; set; }
        public virtual ICollection<ContactoCreateDto> Contactos { get; set; } = [];
        public virtual AntecedenteDto? Antecedente { get; set; }
    }
}
