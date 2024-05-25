namespace MedicalRecord_API.Models.Dtos.Medicamento
{
    public class MedicamentoCreateDto
    {
        public string Codigo { get; set; } = null!;

        public string Tipo { get; set; } = null!;

        public string? NombreComercial { get; set; }

        public string? NombreGenerico { get; set; }

        public string? Estado { get; set; }

        public string? Dosis { get; set; }

        public string? Indicacion { get; set; }

        public int IdPresentacion { get; set; }

        public int IdLaboratorio { get; set; }
    }
}
