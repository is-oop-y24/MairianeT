using System;
using System.Collections.Generic;
using Isu.Entities;

namespace IsuExtra.Entities
{
    public class DaySchedule
    {
        private readonly List<Lesson> lessons;
        private int _maxLessonsNumber = 6;

        public DaySchedule()
        {
            lessons = new List<Lesson>(_maxLessonsNumber);
        }

        public bool NewLesson(int lessonNumber, string teacher, string audience, Group group)
        {
            if (lessons[lessonNumber] != null) return false;
            lessons[lessonNumber] = new Lesson(lessonNumber, teacher, audience, group);
            return true;
        }

        public bool NewLesson(Lesson lesson)
        {
            if (lessons[lesson.LessonNumber()] != null) return false;
            lessons[lesson.LessonNumber()] = lesson;
            return true;
        }

        public bool RemoveLesson(int lessonNumber)
        {
            if (lessons[lessonNumber] == null) return false;
            lessons[lessonNumber] = null;
            return true;
        }

        public bool IsFreeLesson(int lessonNumber)
        {
            return lessons[lessonNumber] == null;
        }

        public bool AreIntersections(DaySchedule current)
        {
            foreach (Lesson lesson in lessons)
            {
                if (lesson != null && !current.IsFreeLesson(lesson.LessonNumber())) return false;
            }

            return true;
        }

        public Lesson GetLesson(int lessonNumber)
        {
            return lessons[lessonNumber];
        }

        public void Union(DaySchedule newSchedule)
        {
            for (int i = 0; i < _maxLessonsNumber; i++)
            {
                if (newSchedule.IsFreeLesson(i)) continue;
                if (lessons[i] == null)
                {
                    lessons[i] = newSchedule.GetLesson(i);
                }
                else
                {
                    throw new Exception("Lesson intersect");
                }
            }
        }

        public void Remove(DaySchedule current)
        {
            for (int i = 0; i < _maxLessonsNumber; i++)
            {
                if (lessons[i] == current.GetLesson(i)) lessons[i] = null;
            }
        }
    }
}