using System;
using System.Collections.Generic;

namespace MedicalRecord_API.Models;

public partial class Medico
{
    public int IdMedico { get; set; }

    public string NombreMed { get; set; } = null!;

    public string? EspeMed { get; set; }

    public string? NroCmed { get; set; }

    public bool? Estado { get; set; }
}
