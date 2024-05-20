namespace MedicalRecord_API.Utils.encrypt.Interfaces
{
    public interface IUtilsService
    {
        Task<string> ConvertirSha256Async(string input);
    }
}
