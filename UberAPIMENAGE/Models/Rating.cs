using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UberAPIMENAGE.Models
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }
        [Range(1,5)]
        public int Score {  get; set; }
        [Required , MaxLength(250)]
        public string Comments { get; set; }
        public Ride Ride { get; set; }
        [ForeignKey(nameof(User))]
        public int RideId { get; set; }


    }
}
