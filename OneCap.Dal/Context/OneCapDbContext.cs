using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OneCap.Dal.Entities;

namespace OneCap.Dal.Context
{
    public class OneCapDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }

        public OneCapDbContext(DbContextOptions<OneCapDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            // seed the database with dummy data

            builder.Entity<Course>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
        }
    }
}
