using Microsoft.EntityFrameworkCore;
using Diagnostyka.Infrastructure.Persistance;

namespace Diagnostyka.WebAPI
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //W przypadku prawdziwego rozwiazania wskazywa³o by na dane po³¹czeniowe do klastra z baz¹ danych/bazami danych lub load balancera bazy danych w pliku konfiguracyjnym aplikacji 
            string dbFile = Path.Combine(Environment.CurrentDirectory, "Diagnostyka.db");
            builder.Services.AddDbContextFactory<DiagnostykaDbContext>(opt => opt.UseSqlite($"Data Source={dbFile}"));

            builder.Services.AddInfrastructureServices();
            var app = builder.Build();

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
