using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OneCap.Dal.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetCourseByIdAsync(CancellationToken ct, params object[] keyValues);
    }
}
