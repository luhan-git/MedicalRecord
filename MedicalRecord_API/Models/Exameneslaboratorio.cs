using System;
using System.Collections.Generic;

namespace MedicalRecord_API.Models;

public partial class Exameneslaboratorio
{
    public int IdExam { get; set; }

    public string NombreExam { get; set; } = null!;

    public string? NemoExam { get; set; }
}
