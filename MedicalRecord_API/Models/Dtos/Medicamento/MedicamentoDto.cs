namespace MedicalRecord_API.Models.Dtos.Medicamento
{
    public class MedicamentoDto
    {
        public int Id { get; set; }

        public string Codigo { get; set; } = null!;

        public string? NombreGenerico { get; set; }
        public string? NombreComercial { get; set; }

        public string? Estado { get; set; }

        public string? Dosis { get; set; }

        public string? Indicacion { get; set; }

        public int IdPresentacion { get; set; }

        public string Presentacion { get; set; } = null!;

    }
}
