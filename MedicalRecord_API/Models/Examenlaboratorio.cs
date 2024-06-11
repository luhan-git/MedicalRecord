namespace MedicalRecord_API.Models;

public partial class Examenlaboratorio
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Abreviatura { get; set; }

    public virtual ICollection<Detalleexaman> Detalleexamen { get; set; } = new List<Detalleexaman>();
}
