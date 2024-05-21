﻿using System;
using System.Collections.Generic;

namespace MedicalRecord_API.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Clave { get; set; } = null!;

    public string Cargo { get; set; } = null!;

    public string? Especialidad { get; set; }

    public string? NroColMedico { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public DateTime? UltimaSesion { get; set; }

    public virtual ICollection<Consultum> Consulta { get; set; } = new List<Consultum>();
}
