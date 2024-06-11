namespace MedicalRecord_API.Models;

public partial class Distrito
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int IdProvincia { get; set; }

    public virtual Provincium IdProvinciaNavigation { get; set; } = null!;

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
