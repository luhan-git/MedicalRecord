using System;
using System.Collections.Generic;

namespace MedicalRecord_API.Models;

public partial class Ordenesmedica
{
    public int Id { get; set; }

    public int IdConsulta { get; set; }

    public int IdExamen { get; set; }

    public string? NombreExamen { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? Resultados { get; set; }

    public DateTime? FechaResultados { get; set; }

    public bool? IsDelete { get; set; }

    public virtual Consulta IdConsultaNavigation { get; set; } = null!;

    public virtual Examene IdExamenNavigation { get; set; } = null!;
}
