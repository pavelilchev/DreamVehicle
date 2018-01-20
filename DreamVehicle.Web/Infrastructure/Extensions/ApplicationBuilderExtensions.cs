namespace DreamVehicle.Web.Infrastructure.Extensions
{
    using DreamVehicle.Data;
    using DreamVehicle.Services;
    using DreamVehicle.Services.Implementation;
    using DreamVehicle.Services.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System.Threading.Tasks;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDatabaseMigrate(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<DreamVehhicleDbContext>().Database.Migrate();

                var vehiclesService = serviceScope.ServiceProvider.GetService<IVehicleService>();
                Task.Run(async () =>
                {
                    var vehicles = await vehiclesService.Search(string.Empty, string.Empty);
                    if (vehicles.Count == 0)
                    {
                        await vehiclesService.Add(new VehicleServiceModel
                        {
                            Model = "Audi",
                            ManufacturedYear = 2005,
                            HorsePower = 228,
                            Importer = "Happy Cars",
                            Description = "description"
                        });

                        await vehiclesService.Add(new VehicleServiceModel
                        {
                            Model = "BMW",
                            ManufacturedYear = 2006,
                            HorsePower = 162,
                            Importer = "Funky Vehicles",
                            Description = "some other description"
                        });

                        await vehiclesService.Add(new VehicleServiceModel
                        {
                            Model = "Dacia",
                            ManufacturedYear = 2007,
                            HorsePower = 44,
                            Importer = "Nice & Cheap",
                            Description = "another description"
                        });

                        await vehiclesService.Add(new VehicleServiceModel
                        {
                            Model = "Volkswagen",
                            ManufacturedYear = 2010,
                            HorsePower = 96,
                            Importer = "German Automotion",
                            Description = "description once again"
                        });

                        await vehiclesService.Add(new VehicleServiceModel
                        {
                            Model = "Fiat",
                            ManufacturedYear = 2008,
                            HorsePower = 72,
                            Importer = "Bella Italia",
                            Description = "even more description"
                        });
                    }
                })
                .GetAwaiter()
                .GetResult();
            }

            return app;
        }
    }
}
