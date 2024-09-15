using MediatR;
using Microsoft.EntityFrameworkCore;
using Sample.Features.Products.Dtos;
using Sample.Persistence;

namespace Sample.Features.Products.Queries.List
{
    /// <summary>
    /// we are injecting dbcontext for data access
    /// </summary>
    public class ListProductsQueryHandler(AppDbContext context) : IRequestHandler<ListProductQuery, List<ProductDto>>
    {
        public async Task<List<ProductDto>> Handle(ListProductQuery request, CancellationToken cancellationToken)
        {
            return await context.Products
                .Select(p => new ProductDto(p.Id, p.Name, p.Description, p.Price))
                .ToListAsync();               
        }
    }
}
