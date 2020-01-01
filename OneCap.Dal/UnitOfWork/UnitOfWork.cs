using Microsoft.Extensions.DependencyInjection;
using OneCap.Dal.Context;
using OneCap.Dal.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OneCap.Dal.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OneCapDbContext _db;
        private readonly IServiceProvider _serviceProvider;

        public UnitOfWork(OneCapDbContext db, IServiceProvider serviceProvider)
        {
            _db = db;
            _serviceProvider = serviceProvider;
        }

        public ICourseRepository Courses => _serviceProvider.GetService<ICourseRepository>();

        public async Task<int> SaveChangesAsync(CancellationToken ct)
        {
            return await _db.SaveChangesAsync(ct);
        }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
