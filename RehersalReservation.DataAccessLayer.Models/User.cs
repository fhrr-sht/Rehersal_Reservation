using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehersalReservation.DataAccessLayer.Models
{
    public class User
    {
        public int UserID { get; set; }
        public Int16 UserType { get; set; }
        public string UserName { get; set; }
        public string UserMail { get; set; }
        public string UserPhone { get; set; }
    }
}
