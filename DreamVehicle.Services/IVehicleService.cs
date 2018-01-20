namespace DreamVehicle.Services
{
    using DreamVehicle.Services.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IVehicleService
    {
        Task<List<string>> GetAllImporters();

        Task Add(VehicleServiceModel vehicle);

        Task<List<VehicleServiceModel>> Search(string importer, string searched);

        Task<int> TotalCount(string importer, string searched);
    }
}
