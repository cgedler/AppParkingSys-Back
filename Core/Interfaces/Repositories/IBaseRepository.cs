using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    /// <summary>
    /// This class will contain common generic methods that you can reuse with other entities.
    /// </summary>
    /// <typeparam name="TEntity">Represents an entity</typeparam>
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync(); 
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate); 
        Task AddAsync(TEntity entity); 
        void Update(TEntity entity); 
        void Remove(TEntity entity);
    }
}
