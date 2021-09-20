using System.Collections.Generic;

namespace Isu.Entities
{
    public class CourseNumber
    {
        private int _course;
        private List<Group> groups = new List<Group>();
        public CourseNumber(int course)
        {
            _course = course;
        }

        public void AddGroup(Group group)
        {
            groups.Add(group);
        }

        public void RemoveGroup(Group group)
        {
            groups.Remove(group);
        }

        public int GetCourse()
        {
            return _course;
        }
    }
}
