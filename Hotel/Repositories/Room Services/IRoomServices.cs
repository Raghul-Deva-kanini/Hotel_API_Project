using Hotel.Models;

namespace Hotel.Repositories.Room_Services
{
    public interface IRoomServices
    {
        Task<List<Room>?> GetRooms();

        Task<Room> GetRoom(int id);

        Task<List<Room>?> PutRoom(int id, Room room);

        Task<List<Room>> PostRoom(Room room);

        Task<List<Room>> DeleteRoom(int id);
    }
}
