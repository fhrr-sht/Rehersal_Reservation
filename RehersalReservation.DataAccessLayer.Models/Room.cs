using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehersalReservation.DataAccessLayer.Models
{
    public class Room
    {
        public int RehersalRoomID { get; set; }
        public string RehersalRoomName { get; set; }
        public int RehersalRoomSize { get; set; }
        public int RehersalSpaseID { get; set; }
    }
}
