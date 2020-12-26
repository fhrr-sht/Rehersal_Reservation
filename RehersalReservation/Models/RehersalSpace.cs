using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RehersalReservation.Models
{
    public class RehersalSpace
    {
        public int RehersalSpaseID { get; set; }
        [StringLength(20, ErrorMessage = "Name length can't be more than 20.")]
        public string RehersalSpaseName { get; set; }
        public int CityID { get; set; }
        public string Adress { get; set; }
    }
}