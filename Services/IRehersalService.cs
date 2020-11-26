using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IRehersalService
    {
        Task <IEnumerable<RehersalSpase>> GetRehersals();
        Task DeleteRehersal(int rehersalSpaseID);
        Task UpdateRehersal(RehersalSpase rehersalSpase);
        Task <RehersalSpase> GetRehersalByID(int rehersalSpaseID);
        Task InsertRehersal(RehersalSpase rehersalSpase);
        Task<List<RehersalSpase>> GetRehersalByCityID(int cityID);
    }
}
