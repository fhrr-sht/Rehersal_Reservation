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
        Task<List<RehersalSpase>> GetRehersals();
        Task DeleteRehersal(int rehersalSpaseID);
        Task UpdateRehersal(RehersalSpase rehersalSpase);
        Task<RehersalSpase>  GetRehersalByID(int rehersalSpaseID);
        Task InsertRehersal(RehersalSpase rehersalSpase);
    }
}
