using System;
using System.Collections.Generic;

namespace MedicalRecord_API.Models;

public partial class Medicamento
{
    public int Id { get; set; }

    public string Codigo { get; set; } = null!;

    public string? Generico { get; set; }

    public string? Comercial { get; set; }

    public string? Dosis { get; set; }

    public string? Indicacion { get; set; }

    public int? Stock { get; set; }

    public float? Costo { get; set; }

    public string? Ubicacion { get; set; }

    public string? Estado { get; set; }

    public int IdPresentacion { get; set; }

    public int IdLaboratorio { get; set; }

    public bool? IsDelete { get; set; }

    public virtual Laboratorio IdLaboratorioNavigation { get; set; } = null!;

    public virtual Presentacione IdPresentacionNavigation { get; set; } = null!;

    public virtual ICollection<Receta> Receta { get; set; } = new List<Receta>();
}
