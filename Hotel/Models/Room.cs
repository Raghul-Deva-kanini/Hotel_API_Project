using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int room_id { get; set; }
        public string? RoomType { get; set; }
        public int Capacity { get; set; }
        public decimal Price { get; set; }
        public bool Availability { get; set; }

        // Foreign key property
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        // Navigation property
        //public List<Reservation>? Reservations { get; set; }
    }
}
