namespace Sample.Features.Products.Dtos
{
    //Record is immutable by default
    //It is recommended to use record type for DTO
    public record ProductDto(
        Guid Id,
        string Name,
        string Description,
        decimal price);
}
