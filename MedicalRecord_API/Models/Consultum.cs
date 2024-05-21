﻿using System;
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

    public int IdCie { get; set; }

    public int IdUsuario { get; set; }

    public int IdPaciente { get; set; }

    public DateTime? FechaConsulta { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public virtual ICollection<Detalleexaman> Detalleexamen { get; set; } = new List<Detalleexaman>();

    public virtual ICollection<Detalleprocedimiento> Detalleprocedimientos { get; set; } = new List<Detalleprocedimiento>();

    public virtual Cie IdCieNavigation { get; set; } = null!;

    public virtual Paciente IdPacienteNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Medicacion> Medicacions { get; set; } = new List<Medicacion>();

    public virtual ICollection<Medidalente> Medidalentes { get; set; } = new List<Medidalente>();
}
