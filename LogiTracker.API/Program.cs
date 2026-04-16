using LogiTracker.Application.Services;
using LogiTracker.Infrastructure;
using LogiTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LogiTracker.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            // Conexão com o Oracle
            options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        builder.Services.AddScoped<ICarrierRepository, CarrierRepository>();
        builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
        builder.Services.AddScoped<IDriverRepository, DriverRepository>();
        builder.Services.AddScoped<ICargoRepository, CargoRepository>();
        builder.Services.AddScoped<IDeliveryRepository, DeliveryRepository>();

        builder.Services.AddControllers();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
