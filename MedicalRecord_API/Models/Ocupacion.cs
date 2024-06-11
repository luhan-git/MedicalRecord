namespace MedicalRecord_API.Models;

public partial class Ocupacion
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Detalle { get; set; }

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
