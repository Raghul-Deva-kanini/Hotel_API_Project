using Hotel.Models;

namespace Hotel.Repositories.Hotel_Services
{
    public interface IHotelServices
    {
        Task<List<HotelTable>?> GetHotels();

        Task<HotelTable> GetHotelTable(int id);

        Task<List<HotelTable>?> PutHotelTable(int id, HotelTable hotelTable);

        Task<List<HotelTable>> PostHotelTable(HotelTable hotelTable);

        Task<List<HotelTable>> DeleteHotelTable(int id);

        IEnumerable<HotelTable> GetLocationDetails(string location);

        IEnumerable<HotelTable> FilterHotels(decimal minPrice, decimal maxPrice);

        IEnumerable<HotelTable> AmenitiesFilter(string amenityDescription);

        public string GetAvailableRoomCount(int hotelId);


    }
}
