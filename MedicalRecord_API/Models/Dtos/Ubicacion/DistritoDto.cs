namespace MedicalRecord_API.Models.Dtos.Ubicacion
{
    public class DistritoDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public int IdProvincia { get; set; }

        public virtual ProvinciaDto IdProvinciaNavigation { get; set; } = null!;
    }
}
