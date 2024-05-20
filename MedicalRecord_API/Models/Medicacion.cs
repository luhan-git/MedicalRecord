﻿using System;
using System.Collections.Generic;

namespace MedicalRecord_API.Models;

public partial class Medicacion
{
    public int Id { get; set; }

    public int IdConsulta { get; set; }

    public int IdMedicamento { get; set; }

    public string Dosis { get; set; } = null!;

    public string? Indicacion { get; set; }

    public string? OrdenMedica { get; set; }
}