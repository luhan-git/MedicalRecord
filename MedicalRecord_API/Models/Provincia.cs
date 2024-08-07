﻿using System;
using System.Collections.Generic;

namespace MedicalRecord_API.Models;

public partial class Provincia
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int IdDepartamento { get; set; }

    public virtual ICollection<Distrito> Distritos { get; set; } = new List<Distrito>();

    public virtual Departamento IdDepartamentoNavigation { get; set; } = null!;

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
