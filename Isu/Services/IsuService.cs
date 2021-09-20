using System.Collections.Generic;
using Isu.Entities;

namespace Isu.Services
{
    public class IsuService : IIsuService
    {
        private List<CourseNumber> courses = new List<CourseNumber>();
        private List<Group> groups = new List<Group>();
        private List<Student> students = new List<Student>();

        public Group AddGroup(GroupName name)
        {
            var newGroup = new Group(name);
            bool isNewCourse = true;
            foreach (CourseNumber course in courses)
            {
                if (course.GetCourse() == newGroup.Course())
                {
                    isNewCourse = false;
                    break;
                }
            }

            var newCourse = new CourseNumber(name.GroupCourse());
            if (isNewCourse) courses.Add(newCourse);
            newCourse.AddGroup(newGroup);

            groups.Add(newGroup);
            return newGroup;
        }

        public Student AddStudent(Group group, string name)
        {
            var newStudent = new Student(name, group);
            students.Add(newStudent);
            group.AddStudent(newStudent);
            return newStudent;
        }

        public void ChangeStudentGroup(Student student, Group newGroup)
        {
            Group oldGroup = student.Group();
            student.ChangeGroupe(newGroup);
            oldGroup.RemoveStudent(student);
            newGroup.AddStudent(student);
        }

        public Group FindGroup(GroupName groupName)
        {
            foreach (Group group in groups)
            {
                if (group.GroupName() == groupName)
                {
                    return group;
                }
            }

            return null;
        }

        public List<Group> FindGroups(CourseNumber courseNumber)
        {
            var courseGroups = new List<Group>();
            foreach (Group group in groups)
            {
                if (group.Course() == courseNumber.GetCourse())
                {
                    courseGroups.Add(group);
                }
            }

            return courseGroups;
        }

        public Student FindStudent(string name)
        {
            foreach (Student student in students)
            {
                if (student.Name() == name)
                {
                    return student;
                }
            }

            return null;
        }

        public List<Student> FindStudents(GroupName groupName)
        {
            var groupStudents = new List<Student>();
            foreach (Student student in students)
            {
                if (student.Group().GroupName() == groupName)
                {
                    groupStudents.Add(student);
                }
            }

            return groupStudents;
        }

        public List<Student> FindStudents(CourseNumber courseNumber)
        {
            var courseStudents = new List<Student>();
            foreach (Student student in students)
            {
                if (student.Course() == courseNumber.GetCourse())
                {
                    courseStudents.Add(student);
                }
            }

            return courseStudents;
        }

        public Student GetStudent(int id)
        {
            foreach (Student student in students)
            {
                if (student.Id() == id)
                {
                    return student;
                }
            }

            return null;
        }
    }
}
