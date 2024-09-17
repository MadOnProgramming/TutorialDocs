using System.Net;

namespace GlobalExceptionHandling.CustomExceptions
{
    public class ProductNotFoundException : BaseException
    {
        public ProductNotFoundException(Guid id) : base($"Product with id {id} not found.", HttpStatusCode.NotFound)
        {
        }
    }
}
