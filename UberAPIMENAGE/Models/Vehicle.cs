using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UberAPIMENAGE.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        public string PlateNumber { get; set; }
        public string Color { get; set; }
        [ForeignKey(nameof(User))]
        public int DriverId { get; set; }
        public User Driver { get; set; }
    }
}
