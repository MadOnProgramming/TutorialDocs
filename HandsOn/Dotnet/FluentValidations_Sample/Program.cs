
using FluentValidation;
using FluentValidations_Sample.Dto;
using FluentValidations_Sample.Validators;

namespace FluentValidations_Sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IValidator<UserRegistrationRequest>, UserRegistratorValidator>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.MapPost("/register", async(UserRegistrationRequest request,IValidator<UserRegistrationRequest> validator) => { 
                var validationResult = await validator.ValidateAsync(request);
                if (!validationResult.IsValid)
                { 
                    return Results.ValidationProblem(validationResult.ToDictionary());
                }

                //perform actual service call for user registration
                //-todo

                return Results.Accepted();
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
        }
    }
}
