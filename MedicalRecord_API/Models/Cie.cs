namespace MedicalRecord_API.Models;

public partial class Cie
{
    public int Id { get; set; }

    public string Codigo { get; set; } = null!;

    public string Enfermedad { get; set; } = null!;

    public virtual ICollection<Consultum> Consulta { get; set; } = new List<Consultum>();
}
