using MediatR;
using Sample.Features.Products.Dtos;
using Sample.Persistence;

namespace Sample.Features.Products.Commands.Update
{
    public class UpdateProductCommandHandler(AppDbContext context) : IRequestHandler<UpdateProductCommand,Guid>
    {
        public async Task<Guid> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await context.Products.FindAsync(request.Id, cancellationToken);
            if (product == null)
            {
                return Guid.Empty;
            }
            product.Name = request.productDto.Name;    
            product.Description = request.productDto.Description;
            product.Price = request.productDto.price;

            await context.SaveChangesAsync(cancellationToken);

            return request.Id;
        }
    }
}
