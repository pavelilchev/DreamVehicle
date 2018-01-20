namespace DreamVehicle.Web.Infrastructure.Mapping
{
    using AutoMapper;
    using DreamVehicle.Models;
    using DreamVehicle.Services.Models;
    using DreamVehicle.Web.Models;
    using System.Collections.Generic;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<VehicleViewModel, VehicleServiceModel>();
            CreateMap<VehicleServiceModel, VehicleViewModel>();
            CreateMap<VehicleServiceModel, Vehicle>();
        }
    }
}
