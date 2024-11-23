using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParkingSys_Back.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<Entities.User> GetUserById(int id);
        Task<IEnumerable<Entities.User>> GetAll();
        Task<Entities.User> CreateUser(Entities.User newUser);
        Task<Entities.User> UpdateUser(int userToBeUpdatedId, Entities.User newUserValues);
        Task DeleteUser(int userId);
    }
}