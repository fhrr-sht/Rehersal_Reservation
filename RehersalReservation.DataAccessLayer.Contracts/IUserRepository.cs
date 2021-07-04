using RehersalReservation.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehersalReservation.DataAccessLayer.Contracts
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
        Task DeleteUser(int UserID);
        Task UpdateUser(User user);
        Task<User> GetUserByID(int userID);
        Task InsertUser(User user);
    }
}
