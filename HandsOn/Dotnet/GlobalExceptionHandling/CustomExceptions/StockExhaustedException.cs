namespace GlobalExceptionHandling.CustomExceptions
{
    public class StockExhaustedException : BaseException
    {
        public StockExhaustedException(Guid id) 
            : base($"Stock exhausted for the product {id}", System.Net.HttpStatusCode.BadGateway)
        { 
        
        }
    }
}
