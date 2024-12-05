﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppParkingSys_Back.Core.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id); 
        Task<IEnumerable<TEntity>> GetAllAsync(); 
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate); 
        Task AddAsync(TEntity entity); 
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}
