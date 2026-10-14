using AutoMapper;
using UberAPIMENAGE.DTOs.UserDTOs;
using UberAPIMENAGE.Models;

namespace UberAPIMENAGE.Mappings.UserMappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User , GetAllUsers>();
        }
    }
}
