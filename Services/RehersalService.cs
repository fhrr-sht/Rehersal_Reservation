using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RehersalService : IRehersalService
    {
        public IEnumerable<RehersalSpase> GetRehersals()
        {
            return new List<RehersalSpase>()
            {
                new RehersalSpase
                {
                    Adress = "adress1", 
                    CityID = 1,
                    RehersalSpaseID = 1,
                    RehersalSpaseName = "Base1"
                },
                new RehersalSpase
                {
                    Adress = "adress2",
                    CityID = 1,
                    RehersalSpaseID = 2,
                    RehersalSpaseName = "Base2"
                }
            };
        }
    }
}
