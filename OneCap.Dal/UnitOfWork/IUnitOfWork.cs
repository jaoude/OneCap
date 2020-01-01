using OneCap.Dal.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OneCap.Dal.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICourseRepository Courses { get; }

        Task<int> SaveChangesAsync(CancellationToken ct);

        int SaveChanges();

        public void Dispose();
    }
}
