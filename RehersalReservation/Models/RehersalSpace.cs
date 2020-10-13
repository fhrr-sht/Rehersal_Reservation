using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RehersalReservation.Models
{
    public class RehersalSpace
    {
        public int RehersalSpaseID { get; set; }
        public string RehersalSpaseName { get; set; }
        public int CityID { get; set; }
        public string Adress { get; set; }
    }
}