using Grpc.Core;
using Hotel.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;

namespace Hotel.Repositories.Hotel_Services
{
    public class HotelServices:IHotelServices
    {
        public HotelDBContext _hotelDBContext;

        public HotelServices(HotelDBContext hotelDBContext)
        {
            _hotelDBContext= hotelDBContext;
        }

        public async Task<List<HotelTable>?> GetHotels()
        {
            var hotel_val = await _hotelDBContext.Hotels.ToListAsync();
            return hotel_val;
        }

        public async Task<HotelTable> GetHotelTable(int id)
        {
            var hotel_data = await _hotelDBContext.Hotels.FindAsync(id);
            if (hotel_data is null)
            {
                return null;
            }
            return hotel_data;
        }

        public async Task<List<HotelTable>?> PutHotelTable(int id, HotelTable hotelTable)
        {
            var hotel_data = await _hotelDBContext.Hotels.FindAsync(id);
            if (hotel_data is null) { return null; }
            hotel_data.HotelId = hotelTable.HotelId;
            hotel_data.Location = hotelTable.Location;
            hotel_data.Description = hotelTable.Description;
            hotel_data.Price = hotelTable.Price;
            hotel_data.Rating = hotelTable.Rating;
            hotel_data.Amenities = hotelTable.Amenities;

            await _hotelDBContext.SaveChangesAsync();
            return await _hotelDBContext.Hotels.ToListAsync();
        }


        public async Task<List<HotelTable>> PostHotelTable(HotelTable hotelTable)
        {
            _hotelDBContext.Hotels.Add(hotelTable);
            await _hotelDBContext.SaveChangesAsync();
            return await _hotelDBContext.Hotels.ToListAsync();
        }

        public async Task<List<HotelTable>> DeleteHotelTable(int id)
        {
            var hotel_data = _hotelDBContext.Hotels.Find(id);
            if (hotel_data is null)
            {
                return null;
            }
            _hotelDBContext.Remove(hotel_data);
            await _hotelDBContext.SaveChangesAsync();
            return await _hotelDBContext.Hotels.ToListAsync();
        }

        public IEnumerable<HotelTable> GetLocationDetails(string location)
        {
            var filteredHotels = _hotelDBContext.Hotels.Where(h=>h.Location==location).ToList();
            return filteredHotels;
        }

        public IEnumerable<HotelTable> FilterHotels(decimal minPrice, decimal maxPrice)
        {
            var filteredHotels = _hotelDBContext.Hotels.Where(h => h.Price >= minPrice && h.Price <= maxPrice).ToList();
            return filteredHotels;
        }

        public IEnumerable<HotelTable> AmenitiesFilter(string amenityDescription)
        {
            var filteredHotels = _hotelDBContext.Hotels.Where(h => h.Amenities.Contains(amenityDescription)).ToList();
            return filteredHotels;
        }

        public string GetAvailableRoomCount(int hotelId)
        {
            var availableRoomCount = _hotelDBContext.Rooms.Count(r => r.HotelId == hotelId && r.Availability);
            if (availableRoomCount == 0)
            {
                return string.Empty;
            }

            return availableRoomCount.ToString();
        }

    }
}
