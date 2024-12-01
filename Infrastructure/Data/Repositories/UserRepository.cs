using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        { 
        }

        async Task<User?> IUserRepository.GetUserByEmailAsync(string email)
        { 
            return await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
        }

        async Task<User?> IBaseRepository<User>.GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        Task<IEnumerable<User>> IBaseRepository<User>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<User>> IBaseRepository<User>.FindAsync(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        Task IBaseRepository<User>.AddAsync(User entity)
        {
            _context.Users.Add(entity); 
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        void IBaseRepository<User>.Update(User entity)
        {
            _context.Users.Update(entity); 
            _context.SaveChanges();
        }

        void IBaseRepository<User>.Remove(User entity)
        {
            var user = _context.Users.Find(entity.Id); 
            if (user != null) 
            { 
                _context.Users.Remove(user); 
                _context.SaveChanges(); 
            }
        }
    }
}
