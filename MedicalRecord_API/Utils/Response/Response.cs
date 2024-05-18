using System.Net;

namespace MedicalRecord_API.Utils.Response
{
    public class Response
    {
        public HttpStatusCode Status { set; get; }
        public bool IsExitoso { set; get; } = false;
        public List<string>? ErrorMensajes { set; get; }
        public Object? Resultado { set; get; }
    }
}
