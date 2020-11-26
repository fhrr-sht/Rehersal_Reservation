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
    public class RehersalRepository : BaseRepository, IRehersalRepository
    {
        public async Task DeleteRehersal(int rehersalSpaseID)
        {
            SqlParameter[] parameters =
                {
                new SqlParameter("@RehersalSpaseID", SqlDbType.Int) { Value = rehersalSpaseID}
                };
            await ExecuteProcedure("DeleteRehersal", parameters);

        }

        public async Task<List<RehersalSpase>> GetRehersalByCityID(int cityID)
        {
            List<RehersalSpase> rehersalSpases = new List<RehersalSpase>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("GetRehersalByCityID", conn);
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
                        RehersalSpase rehersalSpase = new RehersalSpase();
                        rehersalSpase.Adress = rdr["Adress"].ToString();
                        rehersalSpase.CityID = int.Parse(rdr["CityID"].ToString());
                        rehersalSpase.RehersalSpaseName = rdr["RehersalSpaseName"].ToString();
                        rehersalSpase.RehersalSpaseID = int.Parse(rdr["RehersalSpaseID"].ToString());
                        rehersalSpases.Add(rehersalSpase);
                    }
                }
            }
            return rehersalSpases;
        }

        public async Task<RehersalSpase>  GetRehersalByID(int rehersalSpaseID)
        {
            RehersalSpase rehersalSpase = new RehersalSpase();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("GetRehersalByID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parameters =
                {
                new SqlParameter("@RehersalSpaseID", SqlDbType.Int) { Value = rehersalSpaseID}
                };
                cmd.Parameters.AddRange(parameters.ToArray());
                using (SqlDataReader rdr = await cmd.ExecuteReaderAsync())
                {
                    while (rdr.Read())
                    {
                        rehersalSpase.Adress = rdr["Adress"].ToString();
                        rehersalSpase.CityID = int.Parse(rdr["CityID"].ToString());
                        rehersalSpase.RehersalSpaseName = rdr["RehersalSpaseName"].ToString();
                        rehersalSpase.RehersalSpaseID = int.Parse(rdr["RehersalSpaseID"].ToString());               
                    }
                }
            }
            return rehersalSpase;
        }

        public async Task<List<RehersalSpase>> GetRehersals()
        {
            List<RehersalSpase> rehersalSpases = new List<RehersalSpase>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("GetRehersal", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader rdr = await cmd.ExecuteReaderAsync())
                {
                    while (rdr.Read())
                    {
                        RehersalSpase rehersalSpase = new RehersalSpase();
                        rehersalSpase.Adress = rdr["Adress"].ToString();
                        rehersalSpase.CityID = int.Parse(rdr["CityID"].ToString());
                        rehersalSpase.RehersalSpaseName = rdr["RehersalSpaseName"].ToString();
                        rehersalSpase.RehersalSpaseID = int.Parse(rdr["RehersalSpaseID"].ToString());
                        rehersalSpases.Add(rehersalSpase);
                    }
                }
            }
            return rehersalSpases;
        }

        public async Task InsertRehersal(RehersalSpase rehersalSpase)
        {
            SqlParameter[] parameters =
                {
                    new SqlParameter("@RehersalSpaseName", SqlDbType.NVarChar, 50) { Value = rehersalSpase.RehersalSpaseName},
                    new SqlParameter("@CityID", SqlDbType.Int) { Value = rehersalSpase.CityID},
                    new SqlParameter("@Adress", SqlDbType.NVarChar, 50) { Value = rehersalSpase.Adress}
                };
            await ExecuteProcedure("InsertRehersal", parameters);
        }

        public async Task UpdateRehersal(RehersalSpase rehersalSpase)
        {
            SqlParameter[] parameters =
                {
                    new SqlParameter("@RehersalSpaseID", SqlDbType.Int) { Value = rehersalSpase.RehersalSpaseID},
                    new SqlParameter("@RehersalSpaseName", SqlDbType.NVarChar, 50) { Value = rehersalSpase.RehersalSpaseName},
                    new SqlParameter("@CityID", SqlDbType.Int) { Value = rehersalSpase.CityID},
                    new SqlParameter("@Adress", SqlDbType.NVarChar, 50) { Value = rehersalSpase.Adress}
                };
            await ExecuteProcedure("UpdateRehersal", parameters);
        }
    }
}
