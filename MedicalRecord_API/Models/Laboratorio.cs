using System;
using System.Collections.Generic;

namespace MedicalRecord_API.Models;

public partial class Laboratorio
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Abreviatura { get; set; }

    public virtual ICollection<Medicamento> Medicamentos { get; set; } = new List<Medicamento>();
}
