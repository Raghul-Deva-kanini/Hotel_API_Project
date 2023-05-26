using Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Repositories.Room_Services
{
    public class RoomServices:IRoomServices
    {
        public HotelDBContext _hoteldbContext;

        public RoomServices(HotelDBContext hoteldbContext)
        {
            _hoteldbContext = hoteldbContext;
        }

        public async Task<List<Room>?> GetRooms()
        {
            var room_val = await _hoteldbContext.Rooms.ToListAsync();
            return room_val;
        }

        public async Task<Room> GetRoom(int id)
        {
            var room_data = await _hoteldbContext.Rooms.FindAsync(id);
            if (room_data is null)
            {
                return null;
            }
            return room_data;
        }

        public async Task<List<Room>?> PutRoom(int id, Room room)
        {
            var room_data = await _hoteldbContext.Rooms.FindAsync(id);
            if (room_data is null) { return null; }
            room_data.room_id = room.room_id;
            room_data.RoomType = room.RoomType;
            room_data.Capacity = room.Capacity;
            room_data.Price = room.Price;
            room_data.Availability= room.Availability;
            room_data.HotelId = room.HotelId;

            await _hoteldbContext.SaveChangesAsync();
            return await _hoteldbContext.Rooms.ToListAsync();
        }

        public async Task<List<Room>> PostRoom(Room room)
        {
            _hoteldbContext.Rooms.Add(room);
            await _hoteldbContext.SaveChangesAsync();
            return await _hoteldbContext.Rooms.ToListAsync();
        }

        public async Task<List<Room>?> DeleteRoom(int id)
        {
            var room_data =  _hoteldbContext.Rooms.Find(id);
            if (room_data is null)
            {
                return null;
            }
            _hoteldbContext.Remove(room_data);
            await _hoteldbContext.SaveChangesAsync();
            return await _hoteldbContext.Rooms.ToListAsync();
        }
    }
}
