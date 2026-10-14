using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UberAPIMENAGE.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public double Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public DateTime PaymentDate { get; set; }
        public Ride Ride { get; set; }
        [ForeignKey(nameof(User))]
        public int RideId { get; set; }
    }
}
