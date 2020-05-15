using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class MockStudentRespository : IstudentRespository
    {
        private List<Student> _Students;
        public MockStudentRespository()
        {
            _Students = new List<Student>()
            {
                new Student{Id=1,Name="张珊",ClassNeme=ClassName.FirstGrade,Email="1099550751@qq.com"},
                new Student{Id=2,Name="李四",ClassNeme=ClassName.SecondGrade,Email="1099550751@qq.com"},
                new Student{Id=3,Name="王二麻子",ClassNeme=ClassName.GradeThree,Email="1099550751@qq.com"}
            };
        }

        public Student Add(Student student)
        {
            student.Id = _Students.Max(s => s.Id) + 1;
            _Students.Add(student);
            return student;
        }

        public Student Delete(int id)
        {
            Student student = _Students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                _Students.Remove(student);
            }
            return student;
        }

        public Student GetStudent(int Id)
        {
            return _Students.FirstOrDefault(p => p.Id == Id);
        }

        public IEnumerable<Student> GetStudents()
        {
            return _Students;
        }

        public Student Updata(Student student)
        {
            Student stu = _Students.FirstOrDefault(s => s.Id == student.Id);
            if (stu != null)
            {
                stu = student;
            }
            return stu;
        }
    }
}
