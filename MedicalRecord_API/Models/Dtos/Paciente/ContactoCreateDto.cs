namespace MedicalRecord_API.Models.Dtos.Paciente
{
    public class ContactoCreateDto
    {
       public int IdPaciente { get; set; }
        public string? Nombre { get; set; }
        public int? IdParentesco { get; set; }
        public string? Telefono { get; set; }
        public string? Celular { get; set; }
    }
}
