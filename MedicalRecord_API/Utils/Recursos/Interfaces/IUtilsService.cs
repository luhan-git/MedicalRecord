namespace MedicalRecord_API.Utils.Recursos.Interfaces
{
    public interface IUtilsService
    {
       Task<string> ConvertirSha256Async(string input);
    }
}
