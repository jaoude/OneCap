using OneCap.Dal.Context;
using OneCap.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OneCap.Dal.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(OneCapDbContext _db) : base(_db)
        {
        }
    }
}
