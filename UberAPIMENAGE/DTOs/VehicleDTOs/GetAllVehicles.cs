using System.ComponentModel.DataAnnotations;

namespace UberAPIMENAGE.DTOs.VehicleDTOs
{
    public class GetAllVehicles
    {
        [Key]
        public int Id { get; set; }
        public string PlateNumber { get; set; }
        public string Color { get; set; }
    }
}
