using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ICityService
    {
        Task<List<City>> GetCities();
        Task DeleteCity(int cityID);
        void UpdateCity(City city);
        Task<City> GetCityByID(int cityID);
        void InsertCity(City city);
    }
}
