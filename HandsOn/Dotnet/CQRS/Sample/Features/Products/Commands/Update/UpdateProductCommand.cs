using MediatR;
using Sample.Features.Products.Dtos;

namespace Sample.Features.Products.Commands.Update
{
    public record UpdateProductCommand(Guid Id,ProductDto productDto) : IRequest<Guid>;
}
