using System;
using System.Collections.Generic;
using System.Linq;
using Isu.Entities;
using Isu.Services;
using IsuExtra.Entities;

namespace IsuExtra.Services
{
    public class IsuExtraService : IIsuExtraService
    {
        private List<Megafaculty> megafaculties;
        private List<OGNP> ognps;
        private List<Student> students;
        private Dictionary<Group, WeekSchedule> scheldules;

        public IsuExtraService()
        {
            megafaculties = new List<Megafaculty>();
            ognps = new List<OGNP>();
            students = new List<Student>();
            scheldules = new Dictionary<Group, WeekSchedule>();
        }

        public Megafaculty AddMegafaculty(string name)
        {
            var megafaculty = new Megafaculty(name);
            megafaculties.Add(megafaculty);
            return megafaculty;
        }

        public OGNP AddOGNP(string megafaculty)
        {
            var newOGNP = new OGNP(megafaculty);
            ognps.Add(newOGNP);
            return newOGNP;
        }

        public CourseNumber AddCourse(int courseNumber, Megafaculty megafaculty)
        {
            CourseNumber course = new CourseNumber(courseNumber);
            megafaculty.AddCourse(course);
            return course;
        }

        public OGNPStream AddOgnpStream(OGNP ognp)
        {
            OGNPStream stream = new OGNPStream();
            ognp.AddStream(stream);

            return stream;
        }

        public Lesson AddLessonOGNP(int lessonNumber, string teacher, string audience)
        {
            return new Lesson(lessonNumber, teacher, audience);
        }

        public Lesson AddLessonMegafaculty(int day, int lessonNumber, string teacher, string audience, Group group)
        {
            Lesson newLesson = new Lesson(lessonNumber, teacher, audience, group);
            scheldules[group].NewLesson(day, newLesson);
            return newLesson;
        }

        public void AddLessonToOGNPStream(OGNPStream stream, int day, Lesson newLesson)
        {
            stream.AddLesson(day, newLesson);
        }

        public void AddStudentToOGNP(OGNPStream stream, Student student)
        {
            if (stream.Schedule().AreIntersections(scheldules[student.Group()])) throw new Exception("Lesson intersection");
            foreach (OGNP ognp in ognps.Where(ognp => ognp.OgnpStreams().Contains(stream)))
            {
                if (student.Group().GroupName().Name()[..1] == ognp.Megafaculty())
                {
                    throw new Exception("It's megafaculty of thi student");
                }

                ognp.NewStudent(student, stream);
            }
        }

        public void RemoveStudentFromOGNP(Student student, OGNPStream stream)
        {
            foreach (OGNP ognp in ognps.Where(ognp => ognp.OgnpStreams().Contains(stream)))
            {
                ognp.RemoveStudent(student);
            }
        }

        public List<OGNPStream> StreamsOnOGNP(OGNP ognp)
        {
            return ognp.OgnpStreams();
        }

        public List<Student> StudentsOnOGNPStream(OGNPStream stream)
        {
            return stream.StudentsOnOGNP();
        }

        public List<Student> FreeStudents(Megafaculty megafaculty)
        {
            var freeStudents = new List<Student>();
            foreach (Student student in students)
            {
                bool studentFree = true;
                foreach (OGNP ognp in ognps)
                {
                    if (ognp.IsStudentOnThisOGNP(student)) studentFree = false;
                }

                if (studentFree) freeStudents.Add(student);
            }

            return freeStudents;
        }
    }
}