using Isu.Entities;
namespace IsuExtra.Entities
{
    public class Class
    {
        private Time _start;
        private string _teacher;
        private int _audience;
        private Group _group;

        public Class(int classNumber, string teacher, int audience, Group group)
        {
            _teacher = teacher;
            _group = group;
            _audience = audience;
            _start = GetTime(classNumber);
        }

        public Class(int classNumber, string teacher, int audience)
        {
            _teacher = teacher;
            _group = null;
            _audience = audience;
            _start = GetTime(classNumber);
        }

        public Time GetTime(int classNumber)
        {
            return classNumber switch
            {
                1 => new Time(8, 20),
                2 => new Time(10, 0),
                3 => new Time(11, 40),
                4 => new Time(13, 30),
                5 => new Time(15, 20),
                6 => new Time(17, 0),
                _ => new Time(0, 0) // empty time
            };
        }

        public string Teacher()
        {
            return _teacher;
        }

        public int Audience()
        {
            return _audience;
        }

        public Time Start()
        {
            return _start;
        }

        public Group Group()
        {
            return _group;
        }

        public int ClassNumber()
        {
            return ClassNumber();
        }
    }
}