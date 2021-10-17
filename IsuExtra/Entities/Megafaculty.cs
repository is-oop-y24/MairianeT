using System.Collections.Generic;
using Isu.Entities;

namespace IsuExtra.Entities
{
    public class Megafaculty
    {
        private string _name;
        private List<CourseNumber> courses;
        private List<StudentOGNP> students;

        public Megafaculty(string name)
        {
            _name = name;
            courses = new List<CourseNumber>();
            students = new List<StudentOGNP>();
        }

        public void AddCourse(CourseNumber course)
        {
            courses.Add(course);
        }

        public void AddStudent(StudentOGNP student)
        {
            students.Add(student);
        }
    }
}