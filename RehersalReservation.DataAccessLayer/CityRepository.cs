using RehersalReservation.DataAccessLayer.Contracts;
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
        public async Task DeleteCity(int cityID)
        {
            SqlParameter[] parameters =
              {
                new SqlParameter("@CityID", SqlDbType.Int) { Value = cityID}
                };
            await ExecuteProcedure("DeleteCity", parameters);
        }

        public async Task<List<City>> GetCities()
        {
            List<City> cities = new List<City>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("GetCity", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader rdr = await cmd.ExecuteReaderAsync())
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

        public async Task<City> GetCityByID(int cityID)
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
                using (SqlDataReader rdr = await cmd.ExecuteReaderAsync())
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

        public async Task InsertCity(City city)
        {
            SqlParameter[] parameters =
               {
                     new SqlParameter("@CityName", SqlDbType.NVarChar, 50) { Value =  city.CityName}
                };
            await ExecuteProcedure("InsertCity", parameters);
        }

        public async Task UpdateCity(City city)
        {
            SqlParameter[] parameters =
                {
                    new SqlParameter("@CityName", SqlDbType.NVarChar, 50) { Value =  city.CityName},
                    new SqlParameter("@CityID", SqlDbType.Int) { Value =  city.CityID},
                };
            await ExecuteProcedure("UpdateCity", parameters);
        }
    }
}
