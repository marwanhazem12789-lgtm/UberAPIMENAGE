using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UberAPIMENAGE.Models
{
    public class Ride
    {
        [Key]
        public int Id { get; set; }
        public string Status { get; set; }
        public int Fare { get; set; }
        public string DropOffLocation { get; set; }
        public string PickupLocation { get; set; }
        public User Rider { get; set; }
        [ForeignKey(nameof(User))]
        public int RiderId { get; set; }

        public User Driver { get; set; }
        [ForeignKey(nameof(User))]
        public int DriverId { get; set; }

        public Payment Payment { get; set; }
        

        public Rating Rating { get; set; }
      


    }
}
