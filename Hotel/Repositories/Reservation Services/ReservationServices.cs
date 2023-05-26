using Hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Repositories.Reservation_Services
{
    public class ReservationServices:IReservationServices
    {
        public HotelDBContext _hotelDBContext;

        public ReservationServices(HotelDBContext hotelDBContext)
        {
            _hotelDBContext= hotelDBContext;
        }

        public async Task<List<Reservation>?> GetReservation()
        {
            var reservation_data = await _hotelDBContext.Reservation.ToListAsync();
            return reservation_data;
        }

        public async Task<Reservation> GetReservation(int id)
        {
            var reservation_data = await _hotelDBContext.Reservation.FindAsync(id);

            
            if (reservation_data is null)
            {
                return null;
            }
            return reservation_data;
        }

        public async Task<List<Reservation>?> PutReservation(int id, Reservation reservation)
        {
            var reservation_data = await _hotelDBContext.Reservation.FindAsync(id);

            if (reservation_data is null)
            {
                return null;
            }
            reservation_data.reservation_id = reservation.reservation_id;
            reservation_data.customer_id= reservation.customer_id;
            reservation_data.room_id= reservation.room_id;
            reservation_data.check_in_date= reservation.check_in_date;
            reservation_data.check_out_date = reservation.check_out_date;
            await _hotelDBContext.SaveChangesAsync();
            return await _hotelDBContext.Reservation.ToListAsync();
        }

        public async Task<List<Reservation>> PostReservation(Reservation reservation)
        {
            _hotelDBContext.Reservation.Add(reservation);
            await _hotelDBContext.SaveChangesAsync();
            return await _hotelDBContext.Reservation.ToListAsync();
        }

        public async Task<List<Reservation>> DeleteReservation(int id)
        {
            var reservation_data = await _hotelDBContext.Reservation.FindAsync(id);

            if (reservation_data is null)
            {
                return null;
            }
            _hotelDBContext.Remove(reservation_data);
            await _hotelDBContext.SaveChangesAsync();
            return await _hotelDBContext.Reservation.ToListAsync();
        }
    }
}
