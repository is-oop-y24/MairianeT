using System;
using System.Collections.Generic;
using System.Text;

namespace Isu.Services
{
    public class IsuService : IIsuService
    {
        public Group AddGroup(string name)
        {

        }

        public Student AddStudent(Group group, string name)
        {
            throw new NotImplementedException();
        }

        public void ChangeStudentGroup(Student student, Group newGroup)
        {
            throw new NotImplementedException();
        }

        public Group FindGroup(string groupName)
        {
            throw new NotImplementedException();
        }

        public List<Group> FindGroups(CourseNumber courseNumber)
        {
            throw new NotImplementedException();
        }

        public Student FindStudent(string name)
        {
            throw new NotImplementedException();
        }

        public List<Student> FindStudents(string groupName)
        {
            throw new NotImplementedException();
        }

        public List<Student> FindStudents(CourseNumber courseNumber)
        {
            throw new NotImplementedException();
        }

        public Student GetStudent(int id)
        {
            throw new NotImplementedException();
        }
    }
}
