namespace MedicalRecord_API.Services.Interfaces
{
    public interface IUtilsService
    {
        Task<string> ConvertirSha256Async(string input);
    }
}
