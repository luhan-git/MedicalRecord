namespace MedicalRecord_API.Services.Interfaces
{
    public interface IUtilsService
    {
        Task<string> ConvertirSha256(string input);
    }
}