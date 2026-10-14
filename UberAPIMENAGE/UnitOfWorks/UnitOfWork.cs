using Microsoft.Identity.Client;
using UberAPIMENAGE.Allcustoms.AuthCustom;
using UberAPIMENAGE.Genarics;
using UberAPIMENAGE.Models;

namespace UberAPIMENAGE.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;


        public IGenaricRepo<Payment> Payment { get; }

        public IGenaricRepo<Rating> Rating { get; }

        public IGenaricRepo<Vehicle> Vehicle { get; }

        public IGenaricRepo<Ride> Ride { get; }
        public IAuthRepo User { get; }






        public UnitOfWork(Context context , IGenaricRepo<Payment> p , IAuthRepo u,  IGenaricRepo<Vehicle>v , IGenaricRepo<Ride> r , IGenaricRepo<Rating> rt)
        {
            _context = context;
            Rating = rt;
            Ride   = r;
            Payment= p;
            Vehicle= v;
            User = u;
        }

      

        public Task<int> Save()
        {
            return _context.SaveChangesAsync();
        }
    }
}
