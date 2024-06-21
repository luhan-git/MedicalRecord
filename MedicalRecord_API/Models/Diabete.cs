using System;
using System.Collections.Generic;

namespace MedicalRecord_API.Models;

public partial class Diabete
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Detalle { get; set; }

    public bool? IsDelete { get; set; }

    public virtual ICollection<Antecedente> Antecedentes { get; set; } = new List<Antecedente>();
}
