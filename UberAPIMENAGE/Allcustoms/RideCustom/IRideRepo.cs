using UberAPIMENAGE.DTOs.RideDTOs;
using UberAPIMENAGE.Genarics;
using UberAPIMENAGE.Models;

namespace UberAPIMENAGE.Allcustoms.RideCustom
{
    public interface IRideRepo : IGenaricRepo<Ride>
    {
        Task<List<GetAllRides>> Search(string Location);
    }
}
