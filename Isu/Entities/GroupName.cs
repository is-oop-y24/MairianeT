﻿using System;
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
            if (name[0] != 'M' || name[1] != '3') throw new IsuException("Invalid group name");
            if (!char.IsDigit(name[2]) || !char.IsDigit(name[3]) || !char.IsDigit(name[4])) throw new IsuException("Incorrect group name");
            _name = name;
            _course = Convert.ToInt32(name[2]);
            _number = (Convert.ToInt32(name[3]) * 10) + Convert.ToInt32(name[4]);
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
