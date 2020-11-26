using Entity;
using RehersalReservation.DataAccessLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RoomService : IRoomService
    {
        private IRoomRepository roomRepository;
        public RoomService(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }
        public async Task DeleteRoom(int roomID)
        {
            await roomRepository.DeleteRoom(roomID);
        }

        public async Task<Room> GetRoomByID(int roomID)
        {
            RehersalReservation.DataAccessLayer.Models.Room data = await this.roomRepository.GetRoomByID(roomID);
            Room rehersalRoom = new Room
            {
                RehersalRoomID = data.RehersalRoomID,
                RehersalSpaseID = data.RehersalSpaseID,
                RehersalRoomName = data.RehersalRoomName,
                RehersalRoomSize = data.RehersalRoomSize
            };
            return rehersalRoom;
        }

        public async Task<List<Room>> GetRoomByRehersalID(int rehersalSpaceID)
        {
            IEnumerable<RehersalReservation.DataAccessLayer.Models.Room> data = await this.roomRepository.GetRoomByRehersalID(rehersalSpaceID);
            List<Room> rooms = data.Select(o =>
            new Room
            {
                RehersalRoomID = o.RehersalRoomID,
                RehersalSpaseID = o.RehersalSpaseID,
                RehersalRoomName = o.RehersalRoomName,
                RehersalRoomSize = o.RehersalRoomSize
            }).ToList();
            return rooms;
        }

        public async Task<List<Room>> GetRooms()
        {
            IEnumerable<RehersalReservation.DataAccessLayer.Models.Room> data = await this.roomRepository.GetRooms();
            List<Room> rooms = data.Select(o =>
            new Room
            {
                RehersalRoomID = o.RehersalRoomID,
                RehersalSpaseID = o.RehersalSpaseID,
                RehersalRoomName = o.RehersalRoomName,
                RehersalRoomSize = o.RehersalRoomSize
            }).ToList();
            return rooms;
        }

        public async Task InsertRoom(Room room)
        {
            await roomRepository.InsertRoom(new RehersalReservation.DataAccessLayer.Models.Room
            {
                RehersalSpaseID = room.RehersalSpaseID,
                RehersalRoomName = room.RehersalRoomName,
                RehersalRoomSize = room.RehersalRoomSize
            });
        }

        public async Task UpdateRoom(Room room)
        {
            await roomRepository.UpdateRoom(new RehersalReservation.DataAccessLayer.Models.Room
            {
                RehersalSpaseID = room.RehersalSpaseID,
                RehersalRoomName = room.RehersalRoomName,
                RehersalRoomSize = room.RehersalRoomSize,
                RehersalRoomID = room.RehersalRoomID,
                
            });
        }
    }
}
