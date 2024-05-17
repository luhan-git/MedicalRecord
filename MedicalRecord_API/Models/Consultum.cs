using System;
using System.Collections.Generic;

namespace MedicalRecord_API.Models;

public partial class Consultum
{
    public int Id { get; set; }

    public string? NumeroConsulta { get; set; }

    public string Motivo { get; set; } = null!;

    public string? EnfermedadActual { get; set; }

    public string? Davsc { get; set; }

    public string? Iavsc { get; set; }

    public string? Davcc { get; set; }

    public string? Iavcc { get; set; }

    public string? Dpio { get; set; }

    public string? Ipio { get; set; }

    public string? Shimer { get; set; }

    public string? ValorK { get; set; }

    public string? Diagnostico { get; set; }

    public int? IdCie { get; set; }

    public int? IdUsuario { get; set; }

    public DateTime? FechaConsulta { get; set; }

    public DateTime? FechaActualizacion { get; set; }
}
