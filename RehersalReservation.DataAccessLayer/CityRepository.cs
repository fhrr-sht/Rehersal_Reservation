﻿using RehersalReservation.DataAccessLayer.Contracts;
using RehersalReservation.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehersalReservation.DataAccessLayer
{
    public class CityRepository : BaseRepository, ICityRepository
    {
        public void DeleteCity(int cityID)
        {
            throw new NotImplementedException();
        }

        public List<City> GetCities()
        {
            List<City> cities = new List<City>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("GetCity", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        City city = new City();
                        city.CityID = int.Parse(rdr["CityID"].ToString());
                        city.CityName = rdr["CityName"].ToString();
                        cities.Add(city);
                    }
                }
            }
            return cities;
        }

        public City GetCityByID(int cityID)
        {
            City city = new City();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("GetCityByID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parameters =
                {
                new SqlParameter("@CityID", SqlDbType.Int) { Value = cityID}
                };
                cmd.Parameters.AddRange(parameters.ToArray());
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        city.CityName = rdr["CityName"].ToString();
                        city.CityID = int.Parse(rdr["CityID"].ToString());             
                    }
                }
            }
            return city;
        }

        public void InsertCity(City city)
        {
            throw new NotImplementedException();
        }

        public void UpdateCity(City city)
        {
            throw new NotImplementedException();
        }
    }
}