using System;
using System.Collections.Generic;

namespace MedicalRecord_API.Models;

public partial class Detallealergium
{
    public int Id { get; set; }

    public int IdPaciente { get; set; }

    public int IdAlergia { get; set; }

    public string? Nombre { get; set; }

    public string? Detalle { get; set; }
}
