using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    class OrderDetail
    {
		public int OrderDetailID { get; set; }
		public int OrderID { get; set; }
		public int RehersalRoomID { get; set; }
		public string Comment { get; set; }
		public DateTime DateStart { get; set; }
		public DateTime DateEnd { get; set; }
		public decimal Price { get; set; }
    }
}
