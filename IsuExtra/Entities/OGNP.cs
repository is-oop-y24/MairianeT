using System.Collections.Generic;
using System.Linq;

namespace IsuExtra.Entities
{
    public class OGNP
    {
        private List<OGNPStream> streams;
        private List<StudentOGNP> students;
        private string _megafaculty;

        public OGNP(string megafaculty)
        {
            streams = new List<OGNPStream>();
            students = new List<StudentOGNP>();
            _megafaculty = megafaculty;
        }

        public void NewStudent(StudentOGNP student, OGNPStream stream)
        {
            students.Add(student);
            stream.NewStudent(student);
            if (!streams.Contains(stream))
            {
                streams.Add(stream);
            }
        }

        public void RemoveStudent(StudentOGNP student)
        {
            students.Remove(student);
            foreach (OGNPStream stream in streams.Where(stream => stream.IsStudentOnThisOGNP(student)))
            {
                stream.RemoveStudent(student);
            }
        }

        public bool IsStudentOnThisOGNP(StudentOGNP student)
        {
            return students.Contains(student);
        }

        public List<OGNPStream> OgnpStreams()
        {
            return streams;
        }
    }
}