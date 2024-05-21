﻿using System;
using System.Collections.Generic;

namespace MedicalRecord_API.Models;

public partial class Departamento
{
    public int Id { get; set; }

    public string Departamento1 { get; set; } = null!;

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();

    public virtual ICollection<Provincium> Provincia { get; set; } = new List<Provincium>();
}
