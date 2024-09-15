using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Sample.Features.Products.Commands.Create;
using Sample.Features.Products.Commands.Delete;
using Sample.Features.Products.Commands.Update;
using Sample.Features.Products.Dtos;
using Sample.Features.Products.Queries.Get;
using Sample.Features.Products.Queries.List;
using Sample.Persistence;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//get
app.MapGet("/products/{id:guid}", async(Guid id,ISender mediatr) => { 
    var product = await mediatr.Send(new GetProductQuery(id));
    if(product == null) return Results.NotFound();
    return Results.Ok<ProductDto>(product);
});
//list
app.MapGet("/products", async(ISender mediatr) => {
    var products = await mediatr.Send(new ListProductQuery());
    return Results.Ok<List<ProductDto>>(products);
});
//create
app.MapPost("/products", async (CreateProductCommand command,ISender mediatr) => {
    var productId = await mediatr.Send(command);
    if (productId == Guid.Empty) return Results.BadRequest();
    return Results.Created($"/products/{productId}", new { id = productId });
});
//delete
app.MapDelete("/products/{id:guid}", async (Guid id,ISender mediatr) => { 
    await mediatr.Send(new DeleteProductCommand(id));
    return Results.NoContent();
});
//update
app.MapPut("/products/{id:guid}", async(Guid id,UpdateProductCommand command,ISender mediatr) =>
{
    // Send the command to the handler
    var productId = await mediatr.Send(command);

    if (productId == Guid.Empty)
        return Results.BadRequest("Product not found.");

    return Results.Ok();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
