using MediatR;
using Sample.Features.Products.Dtos;
using Sample.Persistence;

namespace Sample.Features.Products.Queries.Get
{
    public class GetProductQueryHandler(AppDbContext context) : IRequestHandler<GetProductQuery, ProductDto?>
    {
        public async Task<ProductDto?> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await context.Products
                .FindAsync(request.Id, cancellationToken);
            if (product == null)
            {
                return null;
            }
            return new ProductDto(
                product.Id, 
                product.Name, 
                product.Description, 
                product.Price);
        }
    }
}
