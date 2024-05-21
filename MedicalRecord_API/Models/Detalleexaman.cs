using System;
using System.Collections.Generic;

namespace MedicalRecord_API.Models;

public partial class Detalleexaman
{
    public int Id { get; set; }

    public int IdConsulta { get; set; }

    public int IdExamenLab { get; set; }

    public string? Detalle { get; set; }

    public string? Resultado { get; set; }

    public DateTime? FechaResultado { get; set; }

    public virtual Consultum IdConsultaNavigation { get; set; } = null!;

    public virtual Examenlaboratorio IdExamenLabNavigation { get; set; } = null!;
}
