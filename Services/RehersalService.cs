using Entity;
using RehersalReservation.DataAccessLayer.Contracts;
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
        private IRehersalRepository rehersalRepository;
        public RehersalService(IRehersalRepository rehersalRepository)
        {
            this.rehersalRepository = rehersalRepository;
        }

        public IEnumerable<RehersalSpase> GetRehersals()
        {
            IEnumerable<RehersalReservation.DataAccessLayer.Models.RehersalSpase> data = this.rehersalRepository.GetRehersals();
            IEnumerable<RehersalSpase> rehersalSpaces = data.Select(o =>
            new RehersalSpase
            {
                Adress = o.Adress,
                CityID = o.CityID,
                RehersalSpaseID = o.RehersalSpaseID,
                RehersalSpaseName = o.RehersalSpaseName
            }).ToList();
            return rehersalSpaces;
        }
    }
}
