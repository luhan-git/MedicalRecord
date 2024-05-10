using System;
using System.Collections.Generic;

namespace MedicalRecord_API.Models;

public partial class Procedimiento
{
    public int IdProce { get; set; }

    public string NombreProce { get; set; } = null!;

    public string? NemoProce { get; set; }
}
