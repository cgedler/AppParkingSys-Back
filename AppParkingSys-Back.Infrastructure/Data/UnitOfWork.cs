using AppParkingSys_Back.Core.Interfaces;
using AppParkingSys_Back.Core.Interfaces.Repositories;
using AppParkingSys_Back.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParkingSys_Back.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private Repositories.UserRepository _userRepository;

        public UnitOfWork(AppDbContext context)
        {
            this._context = context;
        }

        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);

        IUserRepository IUnitOfWork.UserRepository => throw new NotImplementedException();

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
