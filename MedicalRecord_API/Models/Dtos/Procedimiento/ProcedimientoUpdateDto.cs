using System.ComponentModel.DataAnnotations;

namespace MedicalRecord_API.Models.Dtos.Procedimiento
{
    public class ProcedimientoUpdateDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "Identificador fuera del rango")]
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Abreviatura { get; set; }
    }
}
