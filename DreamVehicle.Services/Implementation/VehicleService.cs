namespace DreamVehicle.Services.Implementation
{
    using DreamVehicle.Data;

    public class VehicleService : IVehicleService
    {
        private readonly DreamVehhicleDbContext db;

        public VehicleService(DreamVehhicleDbContext db)
        {
            this.db = db;
        }
    }
}
