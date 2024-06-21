using System;
using System.Collections.Generic;

namespace MedicalRecord_API.Models;

public partial class Examene
{
    public int Id { get; set; }

    public string Tipo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public bool? IsDelete { get; set; }

    public virtual ICollection<Ordenesmedica> Ordenesmedicas { get; set; } = new List<Ordenesmedica>();
}
