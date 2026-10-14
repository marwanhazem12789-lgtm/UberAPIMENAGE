using System.ComponentModel.DataAnnotations;

namespace UberAPIMENAGE.DTOs.RideDTOs
{
    public class GetAllRides
    {
        [Key]
        public int Id { get; set; }
        public string Status { get; set; }
        public int Fare { get; set; }
        public string DropOffLocation { get; set; }
        public string PickupLocation { get; set; }
    }
}
