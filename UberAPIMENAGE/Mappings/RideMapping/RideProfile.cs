using AutoMapper;
using UberAPIMENAGE.DTOs.RideDTOs;
using UberAPIMENAGE.Models;

namespace UberAPIMENAGE.Mappings.RideMapping
{
    public class RideProfile : Profile
    {
        public RideProfile()
        {
            CreateMap<Ride, GetAllRides>();
            CreateMap<CreateRide, Ride>();
        }
    }
}
