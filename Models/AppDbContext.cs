using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData
                (
                new Student { Id = 3, ClassNeme = ClassName.GradeThree, Email = "1058@qq.com", Name = "许大伟" }
                 );


            //base.OnModelCreating(modelBuilder);
        }

        public DbSet<Student> Students { get; set; }//实体类型
    }
}
