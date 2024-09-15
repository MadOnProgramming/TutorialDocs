using MediatR;

namespace Sample.Features.Products.Commands.Create
{
    /// <summary>
    /// This command gets properties of a product
    /// and retuns guid
    /// </summary>
    /// <param name="Name"></param>
    /// <param name="Description"></param>
    /// <param name="price"></param>
    public record CreateProductCommand(string Name,string Description,decimal price):IRequest<Guid>;
}
