using System;
using System.Collections.Generic;

namespace MedicalRecord_API.Models;

public partial class Detallealergium
{
    public int Id { get; set; }

    public int IdAlergia { get; set; }

    public int IdPaciente { get; set; }

    public virtual Alergium IdAlergiaNavigation { get; set; } = null!;

    public virtual Paciente IdPacienteNavigation { get; set; } = null!;
}
