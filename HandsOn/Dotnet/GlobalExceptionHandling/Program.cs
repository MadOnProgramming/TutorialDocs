
using GlobalExceptionHandling.CustomExceptions;
using GlobalExceptionHandling.CustomMiddlewares;
using Microsoft.AspNetCore.Diagnostics;

namespace GlobalExceptionHandling
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            #region Method1 - Custom middleware
            //builder.Services.AddTransient<ErrorHandler>();
            #endregion

            #region Method2 - IExcpetionHandler
            //builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            //builder.Services.AddProblemDetails();
            #endregion

            #region Method3 - Multiple IExcpetionHandler
            builder.Services.AddExceptionHandler<ProductNotFoundExceptionHandler>();
            builder.Services.AddExceptionHandler<StockExhaustedExceptionHandler>();
            builder.Services.AddProblemDetails();
            #endregion

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            //simulates exception
            app.MapGet("/", () =>
            {
                throw new StockExhaustedException(Guid.NewGuid());
            });

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            #region Method1 - Custom middleware
            //app.UseMiddleware<ErrorHandler>();
            #endregion

            #region Method2,Method3 - IExcpetionHandler
            app.UseExceptionHandler();
            #endregion

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
