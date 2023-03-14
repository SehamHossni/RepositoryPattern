
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.core.Interfaces;
using RepositoryPattern.EF;
using RepositoryPattern.EF.Repositories;

namespace RepositoryPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            builder.Services.AddDbContext<ApplicationDbContext>(Options =>
            Options.UseSqlServer(builder.Configuration
                .GetConnectionString(name: "CS"),
             b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();
           // builder.Services.AddTransient(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            builder.Services.AddTransient<IUnitOfWork , UnitOfWork>();
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