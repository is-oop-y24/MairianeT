using System;
using System.Collections.Generic;
using Isu.Entities;

namespace IsuExtra.Entities
{
    public class DaySchedule
    {
        private readonly List<Class> classes;
        private int _maxClassesNumber = 6;

        public DaySchedule()
        {
            classes = new List<Class>(_maxClassesNumber);
        }

        public bool NewClass(int classNumber, string teacher, int audience, Group group)
        {
            if (classes[classNumber] != null) return false;
            classes[classNumber] = new Class(classNumber, teacher, audience, group);
            return true;
        }

        public bool NewClass(Class newClass)
        {
            if (classes[newClass.ClassNumber()] != null) return false;
            classes[newClass.ClassNumber()] = newClass;
            return true;
        }

        public bool RemoveClass(int classNumber)
        {
            if (classes[classNumber] == null) return false;
            classes[classNumber] = null;
            return true;
        }

        public bool IsFreeClass(int classNumber)
        {
            return classes[classNumber] == null;
        }

        public bool AreIntersections(DaySchedule current)
        {
            for (int i = 0; i < _maxClassesNumber; i++)
            {
                if (classes[i] != null && !current.IsFreeClass(i))
                {
                    return false;
                }
            }

            return true;
        }

        public Class GetClass(int classNumber)
        {
            return classes[classNumber];
        }

        public void Union(DaySchedule newSchedule)
        {
            for (int i = 0; i < _maxClassesNumber; i++)
            {
                if (newSchedule.IsFreeClass(i)) continue;
                if (classes[i] == null)
                {
                    classes[i] = newSchedule.GetClass(i);
                }
                else
                {
                    throw new Exception("Class intersect");
                }
            }
        }

        public void Remove(DaySchedule current)
        {
            for (int i = 0; i < _maxClassesNumber; i++)
            {
                if (classes[i] == current.GetClass(i)) classes[i] = null;
            }
        }
    }
}