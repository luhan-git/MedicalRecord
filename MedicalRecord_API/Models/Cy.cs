using System;
using System.Collections.Generic;

namespace MedicalRecord_API.Models;

public partial class Cy
{
    public int Id { get; set; }

    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public bool? IsDelete { get; set; }

    public virtual ICollection<Consulta> Consulta { get; set; } = new List<Consulta>();
}
