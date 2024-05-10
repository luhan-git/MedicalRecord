using System;
using System.Collections.Generic;

namespace MedicalRecord_API.Models;

public partial class Cie
{
    public int IdCie { get; set; }

    public string Codcie { get; set; } = null!;

    public string Enfermedad { get; set; } = null!;
}
