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
    /// <summary>
    /// Class <c>BaseRepository<TEntity></c>
    /// Implementations of the repositories defined in the Core
    /// This class will contain common generic methods that you can reuse with other entities.
    /// </summary>
    /// <typeparam name="TEntity">Represents an entity</typeparam>
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _context; 
        private readonly DbSet<TEntity> _dbSet;
        public BaseRepository(ApplicationDbContext context) 
        { 
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public async Task<TEntity?> GetByIdAsync(int id) 
        { 
            return await _dbSet.FindAsync(id); 
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync() 
        { 
            return await _dbSet.ToListAsync() ?? new List<TEntity>();
        }
        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate) 
        { 
            return await _dbSet.Where(predicate).ToListAsync() ?? new List<TEntity>();
        }
        public async Task AddAsync(TEntity entity) 
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _dbSet.AddAsync(entity); 
        }
        public void Update(TEntity entity) 
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _dbSet.Update(entity); 
        }
        public void Remove(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _dbSet.Remove(entity);
        }
    }
}
