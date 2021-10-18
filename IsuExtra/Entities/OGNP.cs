using System.Collections.Generic;
using System.Linq;
using Isu.Entities;

namespace IsuExtra.Entities
{
    public class OGNP
    {
        private List<OGNPStream> streams;
        private List<Student> students;
        private string _megafaculty;

        public OGNP(string megafaculty)
        {
            streams = new List<OGNPStream>();
            students = new List<Student>();
            _megafaculty = megafaculty;
        }

        public void NewStudent(Student student, OGNPStream stream)
        {
            students.Add(student);
            stream.NewStudent(student);
            if (!streams.Contains(stream))
            {
                streams.Add(stream);
            }
        }

        public void RemoveStudent(Student student)
        {
            students.Remove(student);
            foreach (OGNPStream stream in streams.Where(stream => stream.IsStudentOnThisOGNP(student)))
            {
                stream.RemoveStudent(student);
            }
        }

        public void AddStream(OGNPStream stream)
        {
            streams.Add(stream);
        }

        public bool IsStudentOnThisOGNP(Student student)
        {
            return students.Contains(student);
        }

        public List<OGNPStream> OgnpStreams()
        {
            return streams;
        }

        public string Megafaculty()
        {
            return _megafaculty;
        }
    }
}