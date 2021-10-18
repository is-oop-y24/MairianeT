using System;
using IsuExtra.Entities;
using IsuExtra.Services;
using Isu.Entities;
using Isu.Services;
using NUnit.Framework;

namespace IsuExtra.Tests
{
    public class IsuExtraTests
    {
        private IIsuExtraService _isuExtraService;
        private IIsuService _isuService;

        [SetUp]
        public void SetUp()
        {
            _isuExtraService = new IsuExtraService();
            _isuService = new IsuService();
        }

        public void AddStudentToOGNP_RemoveStudentFromOGNP()
        {
            Megafaculty tint = _isuExtraService.AddMegafaculty("H");
            Megafaculty ktu = _isuExtraService.AddMegafaculty("ktu");
            CourseNumber second = _isuExtraService.AddCourse(2, tint);
            Group third = _isuService.AddGroup(new GroupName("M3203"));
            Student Ivan = _isuService.AddStudent(third, "Ivan");

            OGNP lin = _isuExtraService.AddOGNP(tint.Name());
            OGNP kib = _isuExtraService.AddOGNP(ktu.Name());

            OGNPStream p1 = _isuExtraService.AddOgnpStream(lin);
            OGNPStream k2 = _isuExtraService.AddOgnpStream(kib);

            Class lecture1 = _isuExtraService.AddClassOGNP(2, "Nikolay", "329");
            Class lecture2 = _isuExtraService.AddClassMegafaculty(3, 2, "Alexandr", "332", third);

            _isuExtraService.AddClassToOGNPStream(p1, 3, lecture1);

            _isuExtraService.AddStudentToOGNP(p1, Ivan);
            Assert.IsTrue(p1.IsStudentOnThisOGNP(Ivan));

            _isuExtraService.RemoveStudentFromOGNP(Ivan, p1);
            Assert.IsFalse(p1.IsStudentOnThisOGNP(Ivan));
        }

        public void TryToAddStudentInFullOGNP()
        {
            Megafaculty tint = _isuExtraService.AddMegafaculty("H");
            CourseNumber second = _isuExtraService.AddCourse(2, tint);
            Group third = _isuService.AddGroup(new GroupName("M3203"));
            Student Ivan = _isuService.AddStudent(third, "Ivan");

            OGNP lin = _isuExtraService.AddOGNP(tint.Name());

            OGNPStream p1 = _isuExtraService.AddOgnpStream(lin);

            Assert.Catch<Exception>(() =>
            {
                for (int i = 0; i < 35; i++)
                {
                    _isuExtraService.AddStudentToOGNP(p1, new Student(i.ToString(), third));

                }
            });
        }

        public void TryToAddClassInSameTime()
        {
            Megafaculty tint = _isuExtraService.AddMegafaculty("H");
            CourseNumber second = _isuExtraService.AddCourse(2, tint);
            Group third = _isuService.AddGroup(new GroupName("M3203"));
            Student Ivan = _isuService.AddStudent(third, "Ivan");

            OGNP lin = _isuExtraService.AddOGNP(tint.Name());

            OGNPStream p1 = _isuExtraService.AddOgnpStream(lin);

            Class lecture1 = _isuExtraService.AddClassOGNP(2, "Nikolay", "329");
            Class lecture2 = _isuExtraService.AddClassMegafaculty(3, 2, "Alexandr", "332", third);

            _isuExtraService.AddClassToOGNPStream(p1, 3, lecture1);
            
                Assert.Catch<Exception>(() =>
            {
                _isuExtraService.AddStudentToOGNP(p1, Ivan);
            });
        }

        public void TryAddStudentToOGNPOfHisMegafaculty()
        {
            Megafaculty tint = _isuExtraService.AddMegafaculty("M");
            Megafaculty ktu = _isuExtraService.AddMegafaculty("ktu");
            CourseNumber second = _isuExtraService.AddCourse(2, tint);
            Group third = _isuService.AddGroup(new GroupName("M3203"));
            Student Ivan = _isuService.AddStudent(third, "Ivan");

            OGNP lin = _isuExtraService.AddOGNP(tint.Name());
            OGNP kib = _isuExtraService.AddOGNP(ktu.Name());

            OGNPStream p1 = _isuExtraService.AddOgnpStream(lin);
            OGNPStream k2 = _isuExtraService.AddOgnpStream(kib);

            Class lecture1 = _isuExtraService.AddClassOGNP(2, "Nikolay", "329");
            Class lecture2 = _isuExtraService.AddClassOGNP(4, "Alexandr", "332a");

            _isuExtraService.AddClassToOGNPStream(p1, 3, lecture1);
            _isuExtraService.AddClassToOGNPStream(k2, 4, lecture2);
            
            Assert.Catch<Exception>(() =>
            {
                _isuExtraService.AddStudentToOGNP(p1, Ivan);
            });
        }
    }
}