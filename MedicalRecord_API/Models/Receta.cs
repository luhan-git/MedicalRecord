using System;
using System.Collections.Generic;

namespace MedicalRecord_API.Models;

public partial class Receta
{
    public int Id { get; set; }

    public int IdConsulta { get; set; }

    public string? Diagnostico { get; set; }

    public int IdMedicamento { get; set; }

    public string? Dosis { get; set; }

    public string? Frecuencia { get; set; }

    public string? Indicaciones { get; set; }

    public bool? IsDelete { get; set; }

    public virtual Consulta IdConsultaNavigation { get; set; } = null!;

    public virtual Medicamento IdMedicamentoNavigation { get; set; } = null!;
}
