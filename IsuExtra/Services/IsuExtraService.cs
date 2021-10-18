using System.Collections.Generic;
using System.Linq;
using Isu.Entities;
using Isu.Services;
using IsuExtra.Entities;

namespace IsuExtra.Services
{
    public class IsuExtraService : IsuService, IIsuExtraService
    {
        private List<Megafaculty> megafaculties;
        private List<OGNP> ognps;
        private List<StudentOGNP> students;

        public IsuExtraService()
        {
            megafaculties = new List<Megafaculty>();
            ognps = new List<OGNP>();
            students = new List<StudentOGNP>();
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

        public Class AddClassOGNP(int classNumber, string teacher, int audience)
        {
            return new Class(classNumber, teacher, audience);
        }

        public Class AddClassMegafaculty(int classNumber, string teacher, int audience, Group @group)
        {
            return new Class(classNumber, teacher, audience, group);
        }

        public void AddClassToOGNPStream(OGNPStream stream, int day, Class newClass)
        {
            stream.AddClass(day, newClass);
        }

        public void AddStudentToOGNP(OGNPStream stream, StudentOGNP student)
        {
            foreach (OGNP ognp in ognps.Where(ognp => ognp.OgnpStreams().Contains(stream)))
            {
                ognp.NewStudent(student, stream);
                student.AddToOGNP(stream);
            }
        }

        public void RemoveStudentFromOGNP(StudentOGNP student, OGNPStream stream)
        {
            foreach (OGNP ognp in ognps.Where(ognp => ognp.OgnpStreams().Contains(stream)))
            {
                ognp.RemoveStudent(student);
                student.RemoveFromOGNP(stream);
            }
        }

        public List<OGNPStream> StreamsOnOGNP(OGNP ognp)
        {
            return ognp.OgnpStreams();
        }

        public List<StudentOGNP> StudentsOnOGNPStream(OGNPStream stream)
        {
            return stream.StudentsOnOGNP();
        }

        public List<StudentOGNP> FreeStudents(Megafaculty megafaculty)
        {
            var freeStudents = new List<StudentOGNP>();
            foreach (StudentOGNP student in students)
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