using System;
using System.Collections.Generic;

namespace MedicalRecord_API.Models;

public partial class Medidalente
{
    public int Id { get; set; }

    public int IdConsulta { get; set; }

    public string? Odsphl { get; set; }

    public string? Odcysl { get; set; }

    public string? Odaxil { get; set; }

    public string? Odav { get; set; }

    public string? Oisphl { get; set; }

    public string? Oicysl { get; set; }

    public string? Oiaxil { get; set; }

    public string? Oiav { get; set; }

    public string? Pdl { get; set; }

    public string? Obsl { get; set; }

    public string? Odsphc { get; set; }

    public string? Odcysc { get; set; }

    public string? Odaxic { get; set; }

    public string? Oisphc { get; set; }

    public string? Oicysc { get; set; }

    public string? Oiaxic { get; set; }

    public string? Pdc { get; set; }

    public string? Obsc { get; set; }

    public bool? Preventiva { get; set; }

    public bool? IsDelete { get; set; }

    public virtual Consulta IdConsultaNavigation { get; set; } = null!;
}
