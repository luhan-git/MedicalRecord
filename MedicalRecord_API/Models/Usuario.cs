using System;
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

    public string? Rol { get; set; }

    public bool? IsActivo { get; set; }

    public bool? IsDelete { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public virtual ICollection<Consulta> Consulta { get; set; } = new List<Consulta>();
}
