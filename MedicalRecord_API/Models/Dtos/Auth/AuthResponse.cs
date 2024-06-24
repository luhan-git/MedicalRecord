namespace MedicalRecord_API.Models.Dtos.Auth
{
    public class AuthResponse
    {
        public bool IsSuccess { get; set; } = false;
        public string? Name { get; set; }
        public string? Token { get; set; }
        public string? Msg { get; set; }

    }
}