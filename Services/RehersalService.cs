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

        public void DeleteRehersal(int rehersalSpaseID)
        {
            rehersalRepository.DeleteRehersal(rehersalSpaseID);
        }

        public RehersalSpase GetRehersalByID(int rehersalSpaseID)
        {
            RehersalReservation.DataAccessLayer.Models.RehersalSpase data = this.rehersalRepository.GetRehersalByID(rehersalSpaseID);
            RehersalSpase rehersalSpace = new RehersalSpase
            {
                Adress = data.Adress,
                CityID = data.CityID,
                RehersalSpaseID = data.RehersalSpaseID,
                RehersalSpaseName = data.RehersalSpaseName
            };
            return rehersalSpace;
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

        public void UpdateRehersal(RehersalSpase rehersalSpase)
        {
            rehersalRepository.UpdateRehersal(new RehersalReservation.DataAccessLayer.Models.RehersalSpase
            {
                Adress = rehersalSpase.Adress,
                CityID = rehersalSpase.CityID,
                RehersalSpaseID = rehersalSpase.RehersalSpaseID,
                RehersalSpaseName = rehersalSpase.RehersalSpaseName
            }
                );
        }
    }
}
