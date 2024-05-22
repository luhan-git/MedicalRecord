namespace MedicalRecord_API.Models.Dtos.Ubicacion
{
    public class ProvinciaDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public int IdDepartamento { get; set; }

        public virtual DepartamentoDto IdDepartamentoNavigation { get; set; } = null!;
    }
}
