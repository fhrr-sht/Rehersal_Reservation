﻿using RehersalReservation.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehersalReservation.DataAccessLayer.Contracts
{
    public interface ICityRepository
    {
        List<City> GetCities();
        void DeleteCity(int cityID);
        void UpdateCity(City city);
        City GetCityByID(int cityID);
        void InsertCity(City city);
    }
}