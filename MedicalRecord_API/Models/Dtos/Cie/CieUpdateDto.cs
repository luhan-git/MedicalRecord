
namespace MedicalRecord_API.Models.Dtos.Cie
{
    public class CieUpdateDto
    {

        public int Id { get; set; }
        public string Codigo { get; set; } = null!;
        public string Enfermedad { get; set; } = null!;
    }
}
