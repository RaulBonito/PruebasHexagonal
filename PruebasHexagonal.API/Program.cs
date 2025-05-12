
using Microsoft.OpenApi.Models;
using PruebaHexagonal.Infrastructure.IoC.Extensions;
using System.Diagnostics;

namespace PruebasHexagonal.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

           
            builder.Services.AddServices();
            builder.Services.AddPresenters();
            builder.Services.AddHandlers();
            builder.Services.AddUseCases();
            builder.Services.AddRepositories();
            builder.Services.AddValidators();
            builder.Services.AddMappers();

            // Swagger/OpenAPI configuration
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "PruebasHexagonal API",
                    Version = "v1"
                });
            });

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger(); 
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PruebasHexagonal API v1");

                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
