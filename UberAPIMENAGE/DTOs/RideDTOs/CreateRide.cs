using System.ComponentModel.DataAnnotations.Schema;
using UberAPIMENAGE.Models;

namespace UberAPIMENAGE.DTOs.RideDTOs
{
    public class CreateRide
    {
        public string Status { get; set; }
        public int Fare { get; set; }
        public string DropOffLocation { get; set; }
        public string PickupLocation { get; set; }
        public int RiderId { get; set; }
        public int DriverId { get; set; }

    }
}
