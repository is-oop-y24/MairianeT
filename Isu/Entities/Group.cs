using System.Collections.Generic;
using Isu.Tools;

namespace Isu.Entities
{
    public class Group
    {
        private const int MaxStudentsCount = 30;
        private List<Student> students = new List<Student>();
        private int courseNumber;
        private GroupName groupName;

        public Group(GroupName groupName)
        {
            this.groupName = groupName;
            courseNumber = groupName.GroupCourse();
        }

        public int Course()
        {
            return courseNumber;
        }

        public GroupName GroupName()
        {
            return groupName;
        }

        public int StudentNumber()
        {
            return students.Count + 1;
        }

        public void AddStudent(Student name)
        {
            IsGroupFull();
            students.Add(name);
        }

        public bool RemoveStudent(Student name)
        {
            return students.Remove(name);
        }

        public void IsGroupFull()
        {
            if (students.Count >= MaxStudentsCount)
            {
                throw new IsuException("Maximum number of students is 30");
            }
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
    }
}
