using UberAPIMENAGE.Allcustoms.AuthCustom;
using UberAPIMENAGE.Genarics;
using UberAPIMENAGE.Models;

namespace UberAPIMENAGE.UnitOfWorks
{
    public interface IUnitOfWork
    {
        public IGenaricRepo<Payment> Payment {  get; }
        public IGenaricRepo<Rating> Rating {  get; }
        public IGenaricRepo<Vehicle> Vehicle {  get; }
        public IGenaricRepo<Ride> Ride {  get; }
        public IAuthRepo User { get; }
        public Task<int> Save(); 
    }
}
