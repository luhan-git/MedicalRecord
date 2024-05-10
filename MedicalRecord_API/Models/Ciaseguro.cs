using System;
using System.Collections.Generic;

namespace MedicalRecord_API.Models;

public partial class Ciaseguro
{
    public int IdCia { get; set; }

    public string NombreCia { get; set; } = null!;

    public string? NemoCia { get; set; }
}
