using RehersalReservation.DataAccessLayer.Contracts;
using RehersalReservation.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehersalReservation.DataAccessLayer
{
    class RoomRepository : BaseRepository, IRoomRepository
    {
        public async Task DeleteRoom(int roomID)
        {
            SqlParameter[] parameters =
              {
                new SqlParameter("@RehersalRoomID", SqlDbType.Int) { Value = roomID}
                };
            await ExecuteProcedure("DeleteRoom", parameters);
        }

        public async Task<List<Room>> GetRooms()
        {
            List<Room> rooms = new List<Room>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("GetRoom", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader rdr = await cmd.ExecuteReaderAsync())
                {
                    while (rdr.Read())
                    {
                        Room room = new Room();
                        room.RehersalRoomID = int.Parse(rdr["RehersalRoomID"].ToString());
                        room.RehersalRoomName = rdr["RehersalRoomName"].ToString();
                        room.RehersalRoomID = int.Parse(rdr["RehersalRoomSize"].ToString());
                        room.RehersalSpaseID = int.Parse(rdr["RehersalSpaseID"].ToString());
                        rooms.Add(room);
                    }
                }
            }
            return rooms;
        }

        public async Task<Room> GetRoomByID(int roomID)
        {
            Room room = new Room();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("GetRoomByID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parameters =
                {
                new SqlParameter("@RehersalRoomID", SqlDbType.Int) { Value = roomID}
                };
                cmd.Parameters.AddRange(parameters.ToArray());
                using (SqlDataReader rdr = await cmd.ExecuteReaderAsync())
                {
                    while (rdr.Read())
                    {
                        room.RehersalRoomName = rdr["RehersalRoomName"].ToString();
                        room.RehersalRoomID = int.Parse(rdr["RehersalRoomID"].ToString());
                        room.RehersalRoomSize = int.Parse(rdr["RehersalRoomSize"].ToString());
                        room.RehersalSpaseID = int.Parse(rdr["RehersalSpaseID"].ToString());
                    }
                }
            }
            return room;
        }

        public async Task InsertRoom(Room room)
        {
            SqlParameter[] parameters =
               {
                     new SqlParameter("@RehersalRoomName", SqlDbType.NVarChar, 50) { Value =  room.RehersalRoomName},
                     new SqlParameter("@RehersalSpaseID", SqlDbType.Int) { Value =  room.RehersalSpaseID},
                     new SqlParameter("@RehersalRoomSize", SqlDbType.Int) { Value =  room.RehersalRoomSize},
                };
            await ExecuteProcedure("InsertRoom", parameters);
        }

        public async Task UpdateRoom(Room room)
        {
            SqlParameter[] parameters =
                {
                    new SqlParameter("@RehersalRoomName", SqlDbType.NVarChar, 50) { Value =  room.RehersalRoomName},
                     new SqlParameter("@RehersalSpaseID", SqlDbType.Int) { Value =  room.RehersalSpaseID},
                     new SqlParameter("@RehersalRoomSize", SqlDbType.Int) { Value =  room.RehersalRoomSize},
                     new SqlParameter("@RehersalRoomID", SqlDbType.Int) { Value =  room.RehersalRoomID},
                };
            await ExecuteProcedure("UpdateRoom", parameters);
        }
    }
}
