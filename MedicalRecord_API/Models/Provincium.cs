using System;
using System.Collections.Generic;

namespace MedicalRecord_API.Models;

public partial class Provincium
{
    public int Id { get; set; }

    public string Provincia { get; set; } = null!;

    public int IdDepartamento { get; set; }
}
