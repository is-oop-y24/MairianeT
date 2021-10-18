using System.Collections.Generic;
using Isu.Entities;

namespace IsuExtra.Entities
{
    public class WeekSchedule
    {
        private List<DaySchedule> daySchedules;
        private int _daysOfTheWeek = 7;

        public WeekSchedule()
        {
            daySchedules = new List<DaySchedule>(_daysOfTheWeek);
        }

        public bool IsFreeLesson(int day, int lessonNumber)
        {
            return daySchedules[day].IsFreeLesson(lessonNumber);
        }

        public bool NewLesson(int day, Lesson lesson)
        {
            return daySchedules[day].NewLesson(lesson);
        }

        public void NewDay(int dayOfTheWeek, DaySchedule daySchedule)
        {
            daySchedules[dayOfTheWeek] = daySchedule;
        }

        public bool RemoveLesson(int day, int lessonNumber)
        {
            return daySchedules[day].RemoveLesson(lessonNumber);
        }

        public DaySchedule DaySchedule(int dayNumber)
        {
            return daySchedules[dayNumber];
        }

        public bool AreIntersections(WeekSchedule current)
        {
            for (int i = 0; i < _daysOfTheWeek; i++)
            {
                if (daySchedules[i] == null || current.DaySchedule(i) == null) continue;
                if (!daySchedules[i].AreIntersections(current.DaySchedule(i))) return false;
            }

            return true;
        }

        public void Union(WeekSchedule newSchedule)
        {
            for (int i = 0; i < _daysOfTheWeek; i++)
            {
                if (newSchedule.DaySchedule(i) == null) continue;
                if (daySchedules[i] == null)
                {
                    NewDay(i, newSchedule.DaySchedule(i));
                }
                else
                {
                    daySchedules[i].Union(newSchedule.DaySchedule(i));
                }
            }
        }

        public void Remove(WeekSchedule current)
        {
            for (int i = 0; i < _daysOfTheWeek; i++)
            {
                daySchedules[i].Remove(current.DaySchedule(i));
            }
        }
    }
}