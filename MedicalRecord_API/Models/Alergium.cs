namespace MedicalRecord_API.Models;

public partial class Alergium
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Detallealergium> Detallealergia { get; set; } = new List<Detallealergium>();
}
