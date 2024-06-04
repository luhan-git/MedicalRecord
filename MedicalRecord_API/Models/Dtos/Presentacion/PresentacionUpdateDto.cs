using System.ComponentModel.DataAnnotations;

namespace MedicalRecord_API.Models.Dtos.Presentacion
{
    public class PresentacionUpdateDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Abreviatura { get; set; }
    }
}
