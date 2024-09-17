using System.Net;

namespace GlobalExceptionHandling.CustomExceptions
{
    public class BaseException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public BaseException(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
