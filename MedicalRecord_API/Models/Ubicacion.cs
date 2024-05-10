using System;
using System.Collections.Generic;

namespace MedicalRecord_API.Models;

public partial class Ubicacion
{
    public int IdUbica { get; set; }

    public int TabTipreg { get; set; }

    public string TabCodreg { get; set; } = null!;

    public string? TabNombre { get; set; }

    public string? TabCodrela { get; set; }
}
