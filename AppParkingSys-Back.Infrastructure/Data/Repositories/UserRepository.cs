using AppParkingSys_Back.Core.Entities;
using AppParkingSys_Back.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AppParkingSys_Back.Infrastructure.Data.Repositories
{
    public class UserRepository : BaseRepository<Core.Entities.User>, Core.Interfaces.Repositories.IUserRepository
    {
        internal AppDbContext _context;

        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        User IUserRepository.GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email);
        }
    }
}
