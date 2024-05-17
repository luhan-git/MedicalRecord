using System;
using System.Collections.Generic;

namespace MedicalRecord_API.Models;

public partial class Directorio
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Representante { get; set; }

    public string? Telefono { get; set; }

    public string? Celular { get; set; }

    public string? Email { get; set; }

    public string? Direccion { get; set; }

    public bool? Estado { get; set; }
}
