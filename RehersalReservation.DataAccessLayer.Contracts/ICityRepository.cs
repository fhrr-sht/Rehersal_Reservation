using RehersalReservation.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehersalReservation.DataAccessLayer.Contracts
{
    public interface ICityRepository
    {
        Task<List<City>> GetCities();
        Task DeleteCity(int cityID);
        Task UpdateCity(City city);
        Task<City> GetCityByID(int cityID);
        Task InsertCity(City city);
    }
}
