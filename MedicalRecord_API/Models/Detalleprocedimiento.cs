using System;
using System.Collections.Generic;

namespace MedicalRecord_API.Models;

public partial class Detalleprocedimiento
{
    public int Id { get; set; }

    public int IdConsulta { get; set; }

    public int IdProcedimiento { get; set; }

    public string? Detalle { get; set; }

    public string? Indicacion { get; set; }

    public string? Resultado { get; set; }

    public bool? Imagenes { get; set; }

    public string? Directorio { get; set; }

    public DateTime? FechaResultado { get; set; }

    public virtual Consultum IdConsultaNavigation { get; set; } = null!;

    public virtual Procedimiento IdProcedimientoNavigation { get; set; } = null!;
}
