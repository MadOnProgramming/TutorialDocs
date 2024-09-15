using MediatR;
using Sample.Features.Products.Dtos;

namespace Sample.Features.Products.Queries.Get
{
    public record GetProductQuery(Guid Id) : IRequest<ProductDto>;
}
