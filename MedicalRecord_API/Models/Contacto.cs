using System;
using System.Collections.Generic;

namespace MedicalRecord_API.Models;

public partial class Contacto
{
    public int Id { get; set; }

    public int IdPaciente { get; set; }

    public string? Nombre { get; set; }

    public int? IdParentesco { get; set; }

    public string? Telefono { get; set; }

    public string? Celular { get; set; }

    public bool? IsDelete { get; set; }

    public virtual Paciente IdPacienteNavigation { get; set; } = null!;

    public virtual Parentesco? IdParentescoNavigation { get; set; }
}
