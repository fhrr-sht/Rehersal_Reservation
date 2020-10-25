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
        IEnumerable<RehersalSpase> GetRehersals();
        void DeleteRehersal(int rehersalSpaseID);
        void UpdateRehersal(RehersalSpase rehersalSpase);
        RehersalSpase GetRehersalByID(int rehersalSpaseID);
        void InsertRehersal(RehersalSpase rehersalSpase);
    }
}
