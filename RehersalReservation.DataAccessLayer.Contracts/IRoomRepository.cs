using RehersalReservation.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehersalReservation.DataAccessLayer.Contracts
{
    public interface IRoomRepository
    {
        Task<List<Room>> GetRooms();
        Task DeleteRoom(int roomID);
        Task UpdateRoom(Room room);
        Task<Room> GetRoomByID(int roomID);
        Task InsertRoom(Room room);
    }
}
