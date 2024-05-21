using System;
using System.Collections.Generic;

namespace MedicalRecord_API.Models;

public partial class Parentesco
{
    public int Id { get; set; }

    public string Valor { get; set; } = null!;

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
