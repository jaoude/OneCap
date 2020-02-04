﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OneCap.Dal.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity t);
        Task<TEntity> AddAsync(TEntity t, CancellationToken ct);
        int Count();
        Task<int> CountAsync(CancellationToken ct);
        void Delete(TEntity entity);
        Task<int> DeleteAsync(TEntity entity, CancellationToken ct);
        void Dispose();
        TEntity Find(Expression<Func<TEntity, bool>> match);
        ICollection<TEntity> FindAll(Expression<Func<TEntity, bool>> match);
        Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match, CancellationToken ct);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match, CancellationToken ct);
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        Task<ICollection<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct);
        TEntity Get(int id);
        IQueryable<TEntity> GetAll();
        Task<ICollection<TEntity>> GetAllAsync(CancellationToken ct);
        IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties);
        Task<TEntity> GetAsync(int id, CancellationToken ct);
        void Save();
        Task<int> SaveAsync(CancellationToken ct);
        TEntity Update(TEntity t, object key);
        Task<TEntity> UpdateAsync(TEntity t, object key, CancellationToken ct, byte[] rowVersion = null);
    }
}
