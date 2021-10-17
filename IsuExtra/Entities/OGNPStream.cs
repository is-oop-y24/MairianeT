using System;
using System.Collections.Generic;

namespace IsuExtra.Entities
{
    public class OGNPStream
    {
        private WeekSchedule weekSchedule;
        private List<StudentOGNP> students;
        private int _maxStudentsNumber = 30;

        public OGNPStream()
        {
            weekSchedule = new WeekSchedule();
            students = new List<StudentOGNP>();
        }

        public bool IsStudentOnThisOGNP(StudentOGNP student)
        {
            return students.Contains(student);
        }

        public void NewStudent(StudentOGNP student)
        {
            if (students.Capacity >= _maxStudentsNumber) throw new Exception("Stream is full");
            if (IsStudentOnThisOGNP(student)) throw new Exception("This student is already on this OGNP");
            students.Add(student);
        }

        public void RemoveStudent(StudentOGNP student)
        {
            if (!IsStudentOnThisOGNP(student)) throw new Exception("This student isn't on this OGNP");
            students.Remove(student);
        }

        public WeekSchedule Schedule()
        {
            return weekSchedule;
        }

        public List<StudentOGNP> StudentsOnOGNP()
        {
            return students;
        }
    }
}