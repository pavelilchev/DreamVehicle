namespace DreamVehicle.Data
{
    using DreamVehicle.Models;
    using Microsoft.EntityFrameworkCore;

    public class DreamVehhicleDbContext : DbContext
    {
        public DreamVehhicleDbContext(DbContextOptions<DreamVehhicleDbContext> options)
            : base(options) 
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
