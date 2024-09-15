using MediatR;
using Sample.Features.Products.Dtos;

namespace Sample.Features.Products.Queries.List
{
    /// <summary>
    /// 1)Every query/command would inherit from IRequest<T> 
    /// where T is the type of object to be returned
    /// 2)Query should be record instead of class as query object 
    /// is immutable objects with values alone and without any behaviour.
    /// Record will have built-in equality
    /// Record is not reference type
    /// </summary>
    public record ListProductQuery : IRequest<List<ProductDto>>;
}
