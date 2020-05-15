using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public interface IstudentRespository
    {
        Student GetStudent(int Id);
        IEnumerable<Student> GetStudents();
        Student Add(Student student);

    }
}
