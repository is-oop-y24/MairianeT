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

        public Class AddClassOGNP(int classNumber, string teacher, string audience)
        {
            return new Class(classNumber, teacher, audience);
        }

        public Class AddClassMegafaculty(int day, int classNumber, string teacher, string audience, Group group)
        {
            Class newClass = new Class(classNumber, teacher, audience, group);
            scheldules[group].NewClass(day, newClass);
            return newClass;
        }

        public void AddClassToOGNPStream(OGNPStream stream, int day, Class newClass)
        {
            stream.AddClass(day, newClass);
        }

        public void AddStudentToOGNP(OGNPStream stream, Student student)
        {
            if (stream.Schedule().AreIntersections(scheldules[student.Group()])) throw new Exception("Class intersection");
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