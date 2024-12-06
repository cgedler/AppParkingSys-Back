using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<User?> GetUserById(int id);
        Task<User?> GetUserByEmail(string email);
        Task<IEnumerable<User>> GetAll();
        Task<User> RegisterUser(User user);
        Task<User> UpdateUser(int id, User user);
        Task<User> DeleteUser(int id);
    }
}
