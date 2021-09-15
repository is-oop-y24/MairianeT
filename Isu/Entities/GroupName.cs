using Isu.Tools;

namespace Isu.Entities
{
    public class GroupName
    {
        private int _number;
        private int _course;
        private string _name;

        public GroupName(int number, int course)
        {
            _number = number;
            _course = course;
            _name = "M3" + course;
            if (number >= 0 && number < 10)
            {
                _name += "0" + number;
            }
            else
            {
                _name += number;
            }
        }

        public GroupName(string name)
        {
            if (name[0] != 'M' || name[1] != '3') throw new IsuException("Invalid group name");
            if (!char.IsDigit(name[2]) || !char.IsDigit(name[3]) || !char.IsDigit(name[4])) throw new IsuException("Incorrect group name");
            _name = name;
            _course = name[2] - '0';
            _number = ((name[3] - '0') * 10) + name[4] - '0';
        }

        public int GroupNumber()
        {
            return _number;
        }

        public int GroupCourse()
        {
            return _course;
        }
    }
}
