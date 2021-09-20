namespace Isu.Entities
{
    public class Student
    {
        private string _name;
        private Group group;
        private int courseNumber;
        private int _id;

        public Student(string name, Group group)
        {
            _name = name;
            this.group = group;
            courseNumber = group.Course();
            _id = (group.GroupName().GroupNumber() * 100) + (courseNumber * 10000) + group.StudentNumber();
        }

        public string Name()
        {
            return _name;
        }

        public Group Group()
        {
            return group;
        }

        public int Course()
        {
            return courseNumber;
        }

        public int Id()
        {
            return _id;
        }

        public void ChangeGroupe(Group newGroup)
        {
            if (newGroup.Course() != courseNumber)
            {
                courseNumber = newGroup.Course();
            }

            group = newGroup;
        }
    }
}
