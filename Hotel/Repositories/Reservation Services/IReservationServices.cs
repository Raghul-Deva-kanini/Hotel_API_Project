using Hotel.Models;

namespace Hotel.Repositories.Reservation_Services
{
    public interface IReservationServices
    {
        Task<List<Reservation>?> GetReservation();

        Task<Reservation> GetReservation(int id);

        Task<List<Reservation>?> PutReservation(int id, Reservation reservation);

        Task<List<Reservation>> PostReservation(Reservation reservation);

        Task<List<Reservation>> DeleteReservation(int id);

    }
}
