using System.Collections.Generic;

namespace Isu.Entities
{
    public class CourseNumber
    {
        private int _course;
        private int groupsCount = 0;
        private List<Group> groups = new List<Group>();
        public CourseNumber(int course)
        {
            _course = course;
        }

        public void AddGroup(Group group)
        {
            groups.Add(group);
            groupsCount++;
        }

        public void RemoveGroup(Group group)
        {
            groups.Remove(group);
            groupsCount--;
        }

        public int GroupsCount()
        {
            return groupsCount;
        }

        public int GetCourse()
        {
            return _course;
        }
    }
}
