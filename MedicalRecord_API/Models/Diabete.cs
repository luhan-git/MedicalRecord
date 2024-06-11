namespace MedicalRecord_API.Models;

public partial class Diabete
{
    public int Id { get; set; }

    public string Tipo { get; set; } = null!;

    public string? Detalle { get; set; }

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
