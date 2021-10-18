using System;
using System.Collections.Generic;
using Isu.Entities;

namespace IsuExtra.Entities
{
    public class OGNPStream
    {
        private WeekSchedule weekSchedule;
        private List<Student> students;
        private int _maxStudentsNumber = 30;

        public OGNPStream()
        {
            weekSchedule = new WeekSchedule();
            students = new List<Student>();
        }

        public void AddLesson(int day, Lesson lesson)
        {
            weekSchedule.NewLesson(day, lesson);
        }

        public bool IsStudentOnThisOGNP(Student student)
        {
            return students.Contains(student);
        }

        public void NewStudent(Student student)
        {
            if (students.Capacity >= _maxStudentsNumber) throw new Exception("Stream is full");
            if (IsStudentOnThisOGNP(student)) throw new Exception("This student is already on this OGNP");
            students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            if (!IsStudentOnThisOGNP(student)) throw new Exception("This student isn't on this OGNP");
            students.Remove(student);
        }

        public WeekSchedule Schedule()
        {
            return weekSchedule;
        }

        public List<Student> StudentsOnOGNP()
        {
            return students;
        }
    }
}