﻿namespace MedicalRecord_API.Models.Dtos.Directorio
{
    public class DirectorioCreateDto
    {
        public string Nombre { get; set; } = null!;

        public string? Representante { get; set; }

        public string? Telefono { get; set; }

        public string? Celular { get; set; }

        public string? Email { get; set; }

        public string? Direccion { get; set; }

        public bool? Estado { get; set; }
    }
}