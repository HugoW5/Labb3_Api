using Labb3_Api.Application;
using Labb3_Api.Application.Interfaces;
using Labb3_Api.Data;
using Labb3_Api.Repositories;
using Labb3_Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Labb3_Api
{
	public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<IPersonRepository, PersonRepository>();
            builder.Services.AddScoped<IInterestRepository, InterestRepository>();


            builder.Services.AddScoped<IPersonService, PersonService>();
			builder.Services.AddScoped<IInterestService, InterestService>();

            builder.Services.AddScoped<ILinkRepository, LinkRepository>();
            builder.Services.AddScoped<ILinkService, LinkService>();


			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDbContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
