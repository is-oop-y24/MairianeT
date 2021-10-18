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
            int courseNumber = 2;
            CourseNumber second = _isuExtraService.AddCourse(courseNumber, tint);
            Group third = _isuService.AddGroup(new GroupName("M3203"));
            Student Ivan = _isuService.AddStudent(third, "Ivan");

            OGNP lin = _isuExtraService.AddOGNP(tint.Name());
            OGNP kib = _isuExtraService.AddOGNP(ktu.Name());

            OGNPStream p1 = _isuExtraService.AddOgnpStream(lin);
            OGNPStream k2 = _isuExtraService.AddOgnpStream(kib);

            int classNumber = 2;
            int day = 3; // wednesday
            string audience1 = "329";
            string audience2 = "332a";
            Class lecture1 = _isuExtraService.AddClassOGNP(classNumber, "Nikolay", audience1);
            Class lecture2 = _isuExtraService.AddClassMegafaculty(day, classNumber, "Alexandr", audience2, third);

            _isuExtraService.AddClassToOGNPStream(p1, day, lecture1);

            _isuExtraService.AddStudentToOGNP(p1, Ivan);
            Assert.IsTrue(p1.IsStudentOnThisOGNP(Ivan));

            _isuExtraService.RemoveStudentFromOGNP(Ivan, p1);
            Assert.IsFalse(p1.IsStudentOnThisOGNP(Ivan));
        }

        public void TryToAddStudentInFullOGNP()
        {
            Megafaculty tint = _isuExtraService.AddMegafaculty("H");
            int courseNumber = 2;
            CourseNumber second = _isuExtraService.AddCourse(courseNumber, tint);
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
            int courseNumber = 2;
            CourseNumber second = _isuExtraService.AddCourse(courseNumber, tint);
            Group third = _isuService.AddGroup(new GroupName("M3203"));
            Student Ivan = _isuService.AddStudent(third, "Ivan");

            OGNP lin = _isuExtraService.AddOGNP(tint.Name());

            OGNPStream p1 = _isuExtraService.AddOgnpStream(lin);

            int classNumber = 2;
            int day = 3; // wednesday
            string audience1 = "329";
            string audience2 = "332a";
            Class lecture1 = _isuExtraService.AddClassOGNP(classNumber, "Nikolay", audience1);
            Class lecture2 = _isuExtraService.AddClassMegafaculty(day, classNumber, "Alexandr", audience2, third);

            _isuExtraService.AddClassToOGNPStream(p1, day, lecture1);
            
                Assert.Catch<Exception>(() =>
            {
                _isuExtraService.AddStudentToOGNP(p1, Ivan);
            });
        }

        public void TryAddStudentToOGNPOfHisMegafaculty()
        {
            Megafaculty tint = _isuExtraService.AddMegafaculty("M");
            Megafaculty ktu = _isuExtraService.AddMegafaculty("ktu");
            int courseNumber = 2;
            CourseNumber second = _isuExtraService.AddCourse(courseNumber, tint);
            Group third = _isuService.AddGroup(new GroupName("M3203"));
            Student Ivan = _isuService.AddStudent(third, "Ivan");

            OGNP lin = _isuExtraService.AddOGNP(tint.Name());
            OGNP kib = _isuExtraService.AddOGNP(ktu.Name());

            OGNPStream p1 = _isuExtraService.AddOgnpStream(lin);
            OGNPStream k2 = _isuExtraService.AddOgnpStream(kib);

            int classNumber1 = 2;
            int classNumber2 = 4;
            int day1 = 3; // wednesday
            int day2 = 4; // thursday
            string audience1 = "329";
            string audience2 = "332a";
            Class lecture1 = _isuExtraService.AddClassOGNP(classNumber1, "Nikolay", "329");
            Class lecture2 = _isuExtraService.AddClassOGNP(classNumber2, "Alexandr", "332a");

            _isuExtraService.AddClassToOGNPStream(p1, day1, lecture1);
            _isuExtraService.AddClassToOGNPStream(k2, day2, lecture2);
            
            Assert.Catch<Exception>(() =>
            {
                _isuExtraService.AddStudentToOGNP(p1, Ivan);
            });
        }
    }
}