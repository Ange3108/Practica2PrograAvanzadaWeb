using System.Net;

namespace WebAvanzadaIICuatrimestre.Middleware
{
    public record ExceptionResponse(HttpStatusCode StatusCode,string description);

   
}
