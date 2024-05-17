using System;
using System.Collections.Generic;

namespace MedicalRecord_API.Models;

public partial class Distrito
{
    public int Id { get; set; }

    public string Distrito1 { get; set; } = null!;

    public int IdProvincia { get; set; }
}
