using System.Collections.Generic;
using IsuExtra.Entities;

namespace IsuExtra.Services
{
    public interface IIsuExtraService
    {
        Megafaculty AddMegafaculty(string name);
        OGNP AddOGNP(string megafaculty);
        void AddStudentToOGNP(OGNPStream stream, StudentOGNP student);
        void RemoveStudentFromOGNP(StudentOGNP student, OGNPStream stream);
        List<OGNPStream> StreamsOnOGNP(OGNP ognp);
        List<StudentOGNP> StudentsOnOGNPStream(OGNPStream stream);
        List<StudentOGNP> FreeStudents(Megafaculty megafaculty);
    }
}