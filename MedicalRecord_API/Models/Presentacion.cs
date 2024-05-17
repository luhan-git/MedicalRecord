using System;
using System.Collections.Generic;

namespace MedicalRecord_API.Models;

public partial class Presentacion
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Abreviatura { get; set; }
}
