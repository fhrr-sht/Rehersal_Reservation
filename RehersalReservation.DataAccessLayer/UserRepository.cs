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
    public class UserRepository : BaseRepository, IUserRepository
    {
        public async Task DeleteUser(int userID)
        {
            SqlParameter[] parameters =
              {
                new SqlParameter("@UserID", SqlDbType.Int) { Value = userID}
                };
            await ExecuteProcedure("DeleteUser", parameters);
        }

        public async Task<List<User>> GetUsers()
        {
            List<User> users = new List<User>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("GetUsers", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader rdr = await cmd.ExecuteReaderAsync())
                {
                    while (rdr.Read())
                    {
                        User user = new User();
                        user.UserID = int.Parse(rdr["UserID"].ToString());
                        user.UserType = Int16.Parse(rdr["UserType"].ToString());
                        user.UserName = rdr["UserName"].ToString();
                        user.UserMail = rdr["UserMail"].ToString();
                        user.UserPhone = rdr["UserPhone"].ToString();
                        users.Add(user);
                    }
                }
            }
            return users;
        }

        public async Task<User> GetUserByID(int userID)
        {
            User user = new User();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("GetUserByID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parameters =
                {
                new SqlParameter("@UserID", SqlDbType.Int) { Value = userID}
                };
                cmd.Parameters.AddRange(parameters.ToArray());
                using (SqlDataReader rdr = await cmd.ExecuteReaderAsync())
                {
                    while (rdr.Read())
                    {
                        user.UserID = int.Parse(rdr["UserID"].ToString());
                        user.UserType = Int16.Parse(rdr["UserType"].ToString());
                        user.UserName = rdr["UserName"].ToString();
                        user.UserMail = rdr["UserMail"].ToString();
                        user.UserPhone = rdr["UserPhone"].ToString();
                    }
                }
            }
            return user;
        }

        public async Task InsertUser(User user)
        {
            SqlParameter[] parameters =
               {
                     new SqlParameter("@UserType", SqlDbType.SmallInt) { Value =  user.UserType},
                     new SqlParameter("@UserName", SqlDbType.NVarChar, 50) { Value =  user.UserName},
                     new SqlParameter("@UserMail", SqlDbType.NVarChar, 50) { Value =  user.UserMail},
                     new SqlParameter("@UserPhone", SqlDbType.NVarChar, 50) { Value =  user.UserPhone}
        };
            await ExecuteProcedure("InsertUser", parameters);
        }
        public async Task UpdateUser(User user)
        {
            SqlParameter[] parameters =
                {
                     new SqlParameter("@UserID", SqlDbType.Int) { Value =  user.UserID},
                     new SqlParameter("@UserType", SqlDbType.SmallInt) { Value =  user.UserType},
                     new SqlParameter("@UserName", SqlDbType.NVarChar, 50) { Value =  user.UserName},
                     new SqlParameter("@UserMail", SqlDbType.NVarChar, 50) { Value =  user.UserMail},
                     new SqlParameter("@UserPhone", SqlDbType.NVarChar, 50) { Value =  user.UserPhone}
                };
            await ExecuteProcedure("UpdateUser", parameters);
        }
    }
}
