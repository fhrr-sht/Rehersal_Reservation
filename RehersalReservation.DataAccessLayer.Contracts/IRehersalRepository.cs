using RehersalReservation.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehersalReservation.DataAccessLayer.Contracts
{
    public interface IRehersalRepository
    {
        List<RehersalSpase> GetRehersals();
        void DeleteRehersal(int rehersalSpaseID);
    }
}
