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
    public class UnitOfWork(ApplicationDbContext context, ILoggerFactory loggerFactory) : IUnitOfWork
    {
        private readonly ApplicationDbContext _context = context; 
        private IUserRepository? _userRepository;
        private readonly ILogger _logger = loggerFactory.CreateLogger("logs");

        public IUserRepository UserRepository 
        { 
            get { return _userRepository ??= new UserRepository(_context, _logger); } 
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
