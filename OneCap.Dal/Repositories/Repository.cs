using Microsoft.EntityFrameworkCore;
using OneCap.Dal.Entities;
using OneCap.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OneCap.Dal.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _db;

        public Repository(DbContext db)
        {
            _db = db;
        }
        public void Insert(T item)
        {
            _db.Set<T>().Add(item);
        }

        public T Update(T item, int id)
        {
            if (item == null)
                return null;

            T existing = _db.Set<T>().Find(id);

            if (existing != null)
            {
                _db.Entry(existing).CurrentValues.SetValues(item);
            }
            return existing;
        }
        public async Task<T> UpdateAsync(T item, int id, CancellationToken ct)
        {
            if (item == null)
                return null;

            T existing = await _db.Set<T>().FindAsync(new object[] { id }, ct);
            
            if (existing != null)
            {
                if (item is IHasConcurrency)
                    _db.Entry(existing).OriginalValues["RowVersion"] = ((IHasConcurrency)item).RowVersion;
            
                _db.Entry(existing).CurrentValues.SetValues(item);
            }
            return existing;
        }

        public void Delete(T item)
        {
            _db.Set<T>().Remove(item);
        }

        public IQueryable<T> Select()
        {
            return _db.Set<T>();
        }

        public T Get(int id)
        {
            return _db.Set<T>().Find(id);
        }

        public async Task<T> GetAsync(int id, CancellationToken ct)
        {
            return await _db.Set<T>().FindAsync(new object[] { id }, ct);
        }

        public async Task<ICollection<T>> GetAllAsync(CancellationToken ct)
        {
            return await _db.Set<T>().ToListAsync(ct);
        }

        public T Find(Expression<Func<T, bool>> match)
        {
            return _db.Set<T>().SingleOrDefault(match);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> match, CancellationToken ct)
        {
            return await _db.Set<T>().SingleOrDefaultAsync(match);
        }

        public ICollection<T> FindAll(Expression<Func<T, bool>> match)
        {
            return _db.Set<T>().Where(match).ToList();
        }

        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match, CancellationToken ct)
        {
            return await _db.Set<T>().Where(match).ToListAsync();
        }

        public int Count()
        {
            return _db.Set<T>().Count();
        }

        public Task<int> CountAsync(CancellationToken ct)
        {
            return _db.Set<T>().CountAsync();
        }
    }
}