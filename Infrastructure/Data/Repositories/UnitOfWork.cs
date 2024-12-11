using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    /// <summary>
    /// manage transactions and persistence of multiple repositories in a single operation
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context; 
        private IUserRepository? _userRepository;
       
        public UnitOfWork(ApplicationDbContext context, IUserRepository? userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        public IUserRepository UserRepository 
        {
            get { return _userRepository ??= new UserRepository(_context); }
        }
        public async Task<int> CompleteAsync()
        { 
            return await _context.SaveChangesAsync(); 
        }
        public void Dispose() 
        { 
            _context.Dispose(); 
        }
    }
}
