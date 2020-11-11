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
        public async Task DeleteCity(int cityID)
        {
           await cityRepository.DeleteCity(cityID);
        }

        public async Task<List<City>> GetCities()
        {
            IEnumerable<RehersalReservation.DataAccessLayer.Models.City> data = await this.cityRepository.GetCities();
            List<City> cities = data.Select(o =>
            new City
            {
                CityID = o.CityID,
                CityName = o.CityName
            }).ToList();
            return cities;
        }

        public async Task<City> GetCityByID(int cityID)
        {
            RehersalReservation.DataAccessLayer.Models.City data = await this.cityRepository.GetCityByID(cityID);
            City city = new City
            {
                CityID = data.CityID,
                CityName = data.CityName
            };
            return city;
        }

        public async Task  InsertCity(City city)
        {
            await cityRepository.InsertCity(new RehersalReservation.DataAccessLayer.Models.City
            {               
                CityID = city.CityID,
                CityName = city.CityName
            });
        }

        public async Task UpdateCity(City city)
        {
            await cityRepository.UpdateCity(new RehersalReservation.DataAccessLayer.Models.City
            {
                CityID = city.CityID,
                CityName = city.CityName
            });
        }
    }
}
