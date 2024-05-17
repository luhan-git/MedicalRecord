using System;
using System.Collections.Generic;

namespace MedicalRecord_API.Models;

public partial class Diabete
{
    public int Id { get; set; }

    public string Tipo { get; set; } = null!;

    public string? Detalle { get; set; }
}
