using System.Net;

namespace MedicalRecord_API.Utils.Response
{
    public class Response
    {
        public HttpStatusCode StatusCode { set; get; }
        public bool IsExitoso { set; get; } = true;
        public List<string>? ErrorMensajes { set; get; }
        public Object? Resultado { set; get; }
    }
}
