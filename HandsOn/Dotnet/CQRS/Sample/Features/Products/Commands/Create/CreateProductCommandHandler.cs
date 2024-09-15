using MediatR;
using Sample.Domain;
using Sample.Persistence;

namespace Sample.Features.Products.Commands.Create
{
    public class CreateProductCommandHandler(AppDbContext context) : IRequestHandler<CreateProductCommand, Guid>
    {
        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name,request.Description,request.price);
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            return product.Id;
        }
    }
}
