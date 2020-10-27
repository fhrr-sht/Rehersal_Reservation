using Entity;
using RehersalReservation.DataAccessLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CityService : ICityService
    {
        private ICityRepository cityRepository;
        public CityService(ICityRepository cityRepository)
        {
            this.cityRepository = cityRepository;
        }
        public void DeleteCity(int cityID)
        {
            cityRepository.DeleteCity(cityID);
        }

        public List<City> GetCities()
        {
            IEnumerable<RehersalReservation.DataAccessLayer.Models.City> data = this.cityRepository.GetCities();
            List<City> cities = data.Select(o =>
            new City
            {
                CityID = o.CityID,
                CityName = o.CityName
            }).ToList();
            return cities;
        }

        public City GetCityByID(int cityID)
        {
            RehersalReservation.DataAccessLayer.Models.City data = this.cityRepository.GetCityByID(cityID);
            City city = new City
            {
                CityID = data.CityID,
                CityName = data.CityName
            };
            return city;
        }

        public void InsertCity(City city)
        {
            cityRepository.InsertCity(new RehersalReservation.DataAccessLayer.Models.City
            {               
                CityID = city.CityID,
                CityName = city.CityName
            });
        }

        public void UpdateCity(City city)
        {
            cityRepository.UpdateCity(new RehersalReservation.DataAccessLayer.Models.City
            {
                CityID = city.CityID,
                CityName = city.CityName
            });
        }
    }
}
