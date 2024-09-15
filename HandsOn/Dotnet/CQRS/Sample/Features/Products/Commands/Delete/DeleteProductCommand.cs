using MediatR;

namespace Sample.Features.Products.Commands.Delete
{
    public record DeleteProductCommand(Guid Id):IRequest;
}
