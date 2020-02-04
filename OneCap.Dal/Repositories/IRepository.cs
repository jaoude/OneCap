using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OneCap.Dal.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Insert(T item);
        T Update(T item, int id);
        Task<T> UpdateAsync(T item, int id, CancellationToken ct);
        void Delete(T item);
        IQueryable<T> Select();
        T Get(int id);
        Task<T> GetAsync(int id, CancellationToken ct);
        Task<ICollection<T>> GetAllAsync(CancellationToken ct);
        T Find(Expression<Func<T, bool>> match);
        Task<T> FindAsync(Expression<Func<T, bool>> match, CancellationToken ct);
        ICollection<T> FindAll(Expression<Func<T, bool>> match);
        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match, CancellationToken ct);
        int Count();
        Task<int> CountAsync(CancellationToken ct);
    }
}
