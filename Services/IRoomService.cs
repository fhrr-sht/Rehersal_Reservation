using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IRoomService
    {
        Task<List<Room>> GetRooms();
        Task DeleteRoom(int roomID);
        Task UpdateRoom(Room room);
        Task<Room> GetRoomByID(int roomID);
        Task InsertRoom(Room room);
    }
}
