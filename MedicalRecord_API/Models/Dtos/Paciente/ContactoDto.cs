namespace MedicalRecord_API.Models.Dtos.Paciente
{
    public class ContactoDto
    {
        public int Id { get; set; }

        public int IdPaciente { get; set; }

        public string? Nombre { get; set; }

        public int? IdParentesco { get; set; }
        public string? Parentesco { get; set; }
        public string? Telefono { get; set; }

        public string? Celular { get; set; }

        public bool? IsDelete { get; set; }
    }
}
