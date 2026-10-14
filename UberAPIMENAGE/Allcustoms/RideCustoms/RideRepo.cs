using UberAPIMENAGE.DTOs.RideDTOs;
using UberAPIMENAGE.Genarics;
using UberAPIMENAGE.Models;

namespace UberAPIMENAGE.Allcustoms.RideCustoms
{
    public class RideRepo : GenaricRepo<Ride> 
    {
        private readonly Context _context;
        public RideRepo(Context context):base(context)
        {
            _context = context;
        }

        //public Task<List<GetAllRides>> Pagenation(int pageIndex, int pageSize, string sort)
        //{
        //    return _context.rides.OrderBy(i => i.)
        //}
    }
}
