namespace DreamVehicle.Services.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using DreamVehicle.Data;
    using DreamVehicle.Models;
    using DreamVehicle.Services.Models;
    using Microsoft.EntityFrameworkCore;

    public class VehicleService : IVehicleService
    {
        private readonly DreamVehhicleDbContext db;

        public VehicleService(DreamVehhicleDbContext db)
        {
            this.db = db;
        }

        public async Task Add(VehicleServiceModel vehicle)
        {
            var dbVehicle = Mapper.Map<Vehicle>(vehicle);

            await this.db.Vehicles.AddAsync(dbVehicle);
            await this.db.SaveChangesAsync();
        }

        public async Task<List<string>> GetAllImporters()
        {
            return await this.db.Vehicles.Select(v => v.Importer).ToListAsync();
        }

        public Task<List<VehicleServiceModel>> Search(string importer, string searched)
        {
            IQueryable<Vehicle> query = GetSearchedVehiclesQuery(importer, searched);

            return query
                .OrderBy(v => v.ManufacturedYear)
                .ProjectTo<VehicleServiceModel>()
                .ToListAsync();
        }

        public Task<int> TotalCount(string importer, string searched)
        {
           return GetSearchedVehiclesQuery(importer, searched).CountAsync();
        }

        private IQueryable<Vehicle> GetSearchedVehiclesQuery(string importer, string searched)
        {
            var query = this.db.Vehicles.AsQueryable();
            if (!string.IsNullOrWhiteSpace(importer) && !string.IsNullOrWhiteSpace(searched))
            {
                query = query.Where(v => string.Equals(v.Importer, importer, StringComparison.CurrentCultureIgnoreCase) && v.Description.IndexOf(searched, StringComparison.OrdinalIgnoreCase) >= 0);
            }
            else if (!string.IsNullOrWhiteSpace(importer))
            {
                query = query.Where(v => string.Equals(v.Importer, importer, StringComparison.CurrentCultureIgnoreCase));
            }
            else if (!string.IsNullOrWhiteSpace(searched))
            {
                query = query.Where(v => v.Description.IndexOf(searched, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            return query;
        }

    }
}
