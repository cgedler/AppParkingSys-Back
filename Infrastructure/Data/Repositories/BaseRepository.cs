using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _context; 
        private readonly DbSet<TEntity> _dbSet;
        public readonly ILogger _logger;
        public BaseRepository(ApplicationDbContext context, ILogger logger) 
        { 
            _context = context; 
            _dbSet = _context.Set<TEntity>();
            _logger = logger;
        }
        public async Task<TEntity?> GetByIdAsync(int id) 
        { 
            return await _dbSet.FindAsync(id); 
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync() 
        { 
            return await _dbSet.ToListAsync(); 
        }
        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate) 
        { 
            return await _dbSet.Where(predicate).ToListAsync(); 
        }
        public async Task AddAsync(TEntity entity) 
        { 
            await _dbSet.AddAsync(entity); 
        }
        public void Update(TEntity entity) 
        { 
            _dbSet.Update(entity); 
        }
        public void Remove(TEntity entity) 
        { 
            _dbSet.Remove(entity); 
        }
    }
}
