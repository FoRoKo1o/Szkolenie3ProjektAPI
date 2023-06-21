
using Microsoft.EntityFrameworkCore;
using Serilog;
using Szkolenie3API.Configuration;
using Szkolenie3API.Contrats;
using Szkolenie3API.Data;
using Szkolenie3API.Repository;

namespace Szkolenie3API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("ProjektDbConnectionString");
            builder.Services.AddDbContext<ProjektDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    b => b.AllowAnyHeader()
                        .AllowAnyOrigin()
                        .AllowAnyMethod());
            });

            builder.Host.UseSerilog((ctx, lc) =>
            {
                lc.WriteTo.Console()
                .ReadFrom.Configuration(ctx.Configuration);
            });

            builder.Services.AddAutoMapper(typeof(MapperConfig));

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped<IDogsRepository, DogsRepository>();
            builder.Services.AddScoped<ICatsRepository, CatsRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("AllowAll");
            app.MapControllers();

            app.Run();
        }
    }
}