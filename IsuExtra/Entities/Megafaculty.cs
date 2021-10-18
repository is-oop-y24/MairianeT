using System.Collections.Generic;
using Isu.Entities;

namespace IsuExtra.Entities
{
    public class Megafaculty
    {
        private string _name;
        private List<CourseNumber> courses;
        private List<Student> students;

        public Megafaculty(string name)
        {
            _name = name;
            courses = new List<CourseNumber>();
            students = new List<Student>();
        }

        public void AddCourse(CourseNumber course)
        {
            courses.Add(course);
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public string Name()
        {
            return _name;
        }
    }
}