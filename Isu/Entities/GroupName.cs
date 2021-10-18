using System;
using Isu.Tools;

namespace Isu.Entities
{
    public class GroupName
    {
        private int _number;
        private int _course;
        private string _name;

        public GroupName(string name)
        {
            if (!char.IsDigit(name[2]) || !char.IsDigit(name[3]) || !char.IsDigit(name[4])) throw new IsuException("Incorrect group name");
            _name = name;
            _course = Convert.ToInt32(name[2]);
            _number = Convert.ToInt32(name[3] + name[4]);
            _number = int.Parse(name.Substring(3, 2));
        }

        public int GroupNumber()
        {
            return _number;
        }

        public int GroupCourse()
        {
            return _course;
        }

        public string Name()
        {
            return _name;
        }
    }
}
