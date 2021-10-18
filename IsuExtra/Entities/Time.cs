using System.Dynamic;

namespace IsuExtra.Entities
{
    public class Time
    {
        private int _hours;
        private int _minutes;

        public Time(int hours, int minutes)
        {
            if (hours is >= 0 and < 24) _hours = hours;
            if (minutes is >= 0 and < 60) _minutes = minutes;
        }

        public int Hours()
        {
            return _hours;
        }

        public int Minutes()
        {
            return _minutes;
        }
    }
}