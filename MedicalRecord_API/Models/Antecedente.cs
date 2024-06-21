using System;
using System.Collections.Generic;

namespace MedicalRecord_API.Models;

public partial class Antecedente
{
    public int Id { get; set; }

    public int IdPaciente { get; set; }

    public string? AntecedentesClinicos { get; set; }

    public string? AntecedentesFamiliares { get; set; }

    public string PresionArterial { get; set; } = null!;

    public string? CampoVisual { get; set; }

    public int? IdDiabete { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public bool? IsDelete { get; set; }

    public virtual ICollection<Detallealergia> Detallealergia { get; set; } = new List<Detallealergia>();

    public virtual Diabete? IdDiabeteNavigation { get; set; }

    public virtual Paciente IdPacienteNavigation { get; set; } = null!;
}
