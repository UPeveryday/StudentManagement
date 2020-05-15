using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class SqlStudentRepository : IstudentRespository
    {
        private readonly AppDbContext _context;
        public SqlStudentRepository(AppDbContext context)
        {
            this._context = context;
        }
        public Student Add(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }

        public Student Delete(int id)
        {
            var stu = _context.Students.Find(id);
            if (stu != null)
            {
                _context.Students.Remove(stu);
                _context.SaveChanges();
            }
            return stu;
        }

        public Student GetStudent(int Id)
        {
            return _context.Students.Find(Id);
        }

        public IEnumerable<Student> GetStudents()
        {
            return _context.Students;
        }

        public Student Updata(Student student)
        {
            var stu = _context.Students.Attach(student);
            stu.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return student;
        }
    }
}
