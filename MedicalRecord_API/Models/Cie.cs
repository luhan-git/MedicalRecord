using System;
using System.Collections.Generic;

namespace MedicalRecord_API.Models;

public partial class Cie
{
    public int Id { get; set; }

    public string Codigo { get; set; } = null!;

    public string Enfermedad { get; set; } = null!;
}
