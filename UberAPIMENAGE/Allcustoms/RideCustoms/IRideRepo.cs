using UberAPIMENAGE.Genarics;
using UberAPIMENAGE.Models;

namespace UberAPIMENAGE.Allcustoms.RideCustoms
{
    public interface IRideRepo : IGenaricRepo<Ride>
    {
        Task<List<DTOs.RideDTOs.GetAllRides>> Pagenation(int pageIndex, int pageSize , string sort);
    }
}
