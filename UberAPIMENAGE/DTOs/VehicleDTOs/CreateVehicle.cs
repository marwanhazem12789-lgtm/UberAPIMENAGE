using System.ComponentModel.DataAnnotations.Schema;
using UberAPIMENAGE.Models;

namespace UberAPIMENAGE.DTOs.VehicleDTOs
{
    public class CreateVehicle
    {
        public string PlateNumber { get; set; }
        public string Color { get; set; }
        public int DriverId { get; set; }
    }
}
