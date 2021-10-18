using Isu.Entities;
namespace IsuExtra.Entities
{
    public class Lesson
    {
        private Time _start;
        private string _teacher;
        private string _audience;
        private Group _group;

        public Lesson(int lessonNumber, string teacher, string audience, Group group)
        {
            _teacher = teacher;
            _group = group;
            _audience = audience;
            _start = GetTime(lessonNumber);
        }

        public Lesson(int lessonNumber, string teacher, string audience)
        {
            _teacher = teacher;
            _group = null;
            _audience = audience;
            _start = GetTime(lessonNumber);
        }

        public Time GetTime(int lessonNumber)
        {
            const int first = 1;
            const int second = 2;
            const int third = 3;
            const int fourth = 4;
            const int fifth = 5;
            const int sixth = 6;
            return lessonNumber switch
            {
                first => new Time(8, 20),
                second => new Time(10, 0),
                third => new Time(11, 40),
                fourth => new Time(13, 30),
                fifth => new Time(15, 20),
                sixth => new Time(17, 0),
                _ => new Time(0, 0) // empty time
            };
        }

        public string Teacher()
        {
            return _teacher;
        }

        public string Audience()
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

        public int LessonNumber()
        {
            return LessonNumber();
        }
    }
}