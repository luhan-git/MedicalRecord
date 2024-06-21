using System;
using System.Collections.Generic;

namespace MedicalRecord_API.Models;

public partial class Parentesco
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public bool? IsDelete { get; set; }

    public virtual ICollection<Contacto> Contactos { get; set; } = new List<Contacto>();
}
