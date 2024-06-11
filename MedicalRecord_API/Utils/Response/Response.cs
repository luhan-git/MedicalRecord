using System.Net;

namespace MedicalRecord_API.Utils.Response
{
    public class Response
    {
        public HttpStatusCode Status { set; get; }
        public bool IsSuccess { set; get; } = false;
        public List<string>? ErrorMessages { set; get; } = [];
        public Object? Result { set; get; }
    }
}
