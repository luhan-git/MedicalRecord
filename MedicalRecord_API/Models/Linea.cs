using System;
using System.Collections.Generic;

namespace MedicalRecord_API.Models;

public partial class Linea
{
    public int IdLinea { get; set; }

    public string NombreLinea { get; set; } = null!;

    public string? NemoLinea { get; set; }
}
