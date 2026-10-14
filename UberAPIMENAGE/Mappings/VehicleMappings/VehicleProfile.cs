using AutoMapper;
using UberAPIMENAGE.DTOs.VehicleDTOs;
using UberAPIMENAGE.Models;

namespace UberAPIMENAGE.Mappings.VehicleMappings
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<Vehicle, GetAllVehicles>();
            CreateMap<CreateVehicle, Vehicle>();

        }
    }
}
