using System;
using System.Collections.Generic;

namespace MedicalRecord_API.Models;

public partial class Detallealergia
{
    public int Id { get; set; }

    public int IdAlergia { get; set; }

    public int IdAntecedente { get; set; }

    public string? Reacciones { get; set; }

    public bool? IsDelete { get; set; }

    public virtual Alergia IdAlergiaNavigation { get; set; } = null!;

    public virtual Antecedente IdAntecedenteNavigation { get; set; } = null!;
}
