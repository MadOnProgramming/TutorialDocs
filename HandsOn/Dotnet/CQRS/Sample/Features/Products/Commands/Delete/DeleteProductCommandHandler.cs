using MediatR;
using Sample.Persistence;

namespace Sample.Features.Products.Commands.Delete
{
    public class DeleteProductCommandHandler(AppDbContext context) : IRequestHandler<DeleteProductCommand>
    {
        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            //find the product in db
            var product = await context.Products.FindAsync(request.Id);

            //if product not found
            if (product == null)
                return;

            //remove product
            context.Products.Remove(product);

            //save context
            await context.SaveChangesAsync();
        }
    }
}
