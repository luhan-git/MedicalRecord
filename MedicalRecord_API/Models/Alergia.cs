using System;
using System.Collections.Generic;

namespace MedicalRecord_API.Models;

public partial class Alergia
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public bool? IsDelete { get; set; }

    public virtual ICollection<Detallealergia> Detallealergia { get; set; } = new List<Detallealergia>();
}
