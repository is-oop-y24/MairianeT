using System.Collections.Generic;
using Isu.Entities;
using IsuExtra.Entities;

namespace IsuExtra.Services
{
    public interface IIsuExtraService
    {
        Megafaculty AddMegafaculty(string name);
        OGNP AddOGNP(string megafaculty);
        CourseNumber AddCourse(int courseNumber, Megafaculty megafaculty);
        OGNPStream AddOgnpStream(OGNP ognp);
        Class AddClassOGNP(int classNumber, string teacher, string audience);
        Class AddClassMegafaculty(int classNumber, string teacher, string audience, Group group);
        void AddClassToOGNPStream(OGNPStream stream, int day, Class newClass);
        void AddStudentToOGNP(OGNPStream stream, Student student);
        void RemoveStudentFromOGNP(Student student, OGNPStream stream);
        List<OGNPStream> StreamsOnOGNP(OGNP ognp);
        List<Student> StudentsOnOGNPStream(OGNPStream stream);
        List<Student> FreeStudents(Megafaculty megafaculty);
    }
}