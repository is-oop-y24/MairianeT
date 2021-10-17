using System;
using System.Collections.Generic;
using Isu.Entities;

namespace IsuExtra.Entities
{
    public class StudentOGNP : Student
    {
        private List<OGNPStream> streams;
        private WeekSchedule schedule;

        public StudentOGNP(string name, Group group)
            : base(name, group)
        {
            streams = new List<OGNPStream>();
            schedule = new WeekSchedule();
        }

        public void AddToOGNP(OGNPStream stream)
        {
            if (schedule.AreIntersections(stream.Schedule()))
            {
                schedule.Union(stream.Schedule());
            }
            else
            {
                throw new Exception("The schedule is incorrect");
            }
        }

        public void RemoveFromOGNP(OGNPStream stream)
        {
            schedule.Remove(stream.Schedule());
        }
    }
}