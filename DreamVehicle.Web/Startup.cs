namespace DreamVehicle.Web
{
    using AutoMapper;
    using DreamVehicle.Data;
    using DreamVehicle.Services;
    using DreamVehicle.Services.Implementation;
    using DreamVehicle.Web.Infrastructure.Extensions;
    using DreamVehicle.Web.Infrastructure.Mapping;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DreamVehhicleDbContext>(options =>
                  options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
            });

            Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());

            services.AddTransient<IVehicleService, VehicleService>();

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDatabaseMigrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/home/error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Vehicle}/{action=Index}/{id?}");
            });
        }
    }
}
