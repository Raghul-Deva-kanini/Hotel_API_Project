using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int reservation_id { get; set; }

        [ForeignKey("Customer")]
        public int customer_id { get; set; }
        //public Customer? Customer { get; set; }
        
        [ForeignKey("Room")]
        public int room_id { get; set; }
        //public Room? Room { get; set; }

        [Column(TypeName = "Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime check_in_date  { get; set; }

        [Column(TypeName = "Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime check_out_date { get; set; }
        
        
    }
}
