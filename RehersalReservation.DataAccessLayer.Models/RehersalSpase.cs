using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehersalReservation.DataAccessLayer.Models
{
    public class RehersalSpase
    {
        public int RehersalSpaseID { get; set; }
        public string RehersalSpaseName { get; set; }
        public int CityID { get; set; }
        public string Adress { get; set; }
    }
}

