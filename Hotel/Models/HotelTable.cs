using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models
{
    public class HotelTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HotelId { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public decimal Rating { get; set; }
        public decimal Price { get; set; }
        public string? Amenities { get; set; }
        //public List<Room>? Rooms { get; set; }
    }
}
