using System;
using System.Collections.Generic;

namespace MedicalRecord_API.Models;

public partial class Presentacione
{
    public int IdPresenta { get; set; }

    public string NombrePrese { get; set; } = null!;

    public string NemoPrese { get; set; } = null!;
}
