using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OneCap.Dal.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _db;

        public Repository(DbContext db)
        {
            _db = db;
        }

        public async Task<TEntity> GetCourseByIdAsync(CancellationToken ct, params object[] keyValues)
        {
            return await _db.Set<TEntity>().FindAsync(keyValues, ct);
        }
    }
}
