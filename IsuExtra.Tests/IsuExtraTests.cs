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
            const int courseNumber = 2;
            CourseNumber second = _isuExtraService.AddCourse(courseNumber, tint);
            Group third = _isuService.AddGroup(new GroupName("M3203"));
            Student ivan = _isuService.AddStudent(third, "Ivan");

            OGNP lin = _isuExtraService.AddOGNP(tint.Name());
            OGNP kib = _isuExtraService.AddOGNP(ktu.Name());

            OGNPStream p1 = _isuExtraService.AddOgnpStream(lin);
            OGNPStream k2 = _isuExtraService.AddOgnpStream(kib);

            const int lessonNumber = 2;
            const int day = 3; // wednesday
            const string audience1 = "329";
            Lesson lecture1 = _isuExtraService.AddLessonOGNP(lessonNumber, "Nikolay", audience1);
            
            _isuExtraService.AddLessonToOGNPStream(p1, day, lecture1);

            _isuExtraService.AddStudentToOGNP(p1, ivan);
            Assert.IsTrue(p1.IsStudentOnThisOGNP(ivan));

            _isuExtraService.RemoveStudentFromOGNP(ivan, p1);
            Assert.IsFalse(p1.IsStudentOnThisOGNP(ivan));
        }

        public void TryToAddStudentInFullOGNP()
        {
            Megafaculty tint = _isuExtraService.AddMegafaculty("H");
            const int courseNumber = 2;
            CourseNumber second = _isuExtraService.AddCourse(courseNumber, tint);
            Group third = _isuService.AddGroup(new GroupName("M3203"));
            Student ivan = _isuService.AddStudent(third, "Ivan");

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

        public void TryToAddLessonInSameTime()
        {
            Megafaculty tint = _isuExtraService.AddMegafaculty("H");
            const int courseNumber = 2;
            CourseNumber second = _isuExtraService.AddCourse(courseNumber, tint);
            Group third = _isuService.AddGroup(new GroupName("M3203"));
            Student ivan = _isuService.AddStudent(third, "Ivan");

            OGNP lin = _isuExtraService.AddOGNP(tint.Name());

            OGNPStream p1 = _isuExtraService.AddOgnpStream(lin);

            const int lessonNumber = 2;
            const int day = 3; // wednesday
            const string audience = "329";
            Lesson lecture = _isuExtraService.AddLessonOGNP(lessonNumber, "Nikolay", audience);
            _isuExtraService.AddLessonToOGNPStream(p1, day, lecture);
            
                Assert.Catch<Exception>(() =>
            {
                _isuExtraService.AddStudentToOGNP(p1, ivan);
            });
        }

        public void TryAddStudentToOGNPOfHisMegafaculty()
        {
            Megafaculty tint = _isuExtraService.AddMegafaculty("M");
            Megafaculty ktu = _isuExtraService.AddMegafaculty("ktu");
            const int courseNumber = 2;
            CourseNumber second = _isuExtraService.AddCourse(courseNumber, tint);
            Group third = _isuService.AddGroup(new GroupName("M3203"));
            Student ivan = _isuService.AddStudent(third, "Ivan");

            OGNP lin = _isuExtraService.AddOGNP(tint.Name());
            OGNP kib = _isuExtraService.AddOGNP(ktu.Name());

            OGNPStream p1 = _isuExtraService.AddOgnpStream(lin);
            OGNPStream k2 = _isuExtraService.AddOgnpStream(kib);

            const int lessonNumber1 = 2;
            const int lessonNumber2 = 4;
            const int day1 = 3; // wednesday
            const int day2 = 4; // thursday
            const string audience1 = "329";
            const string audience2 = "332a";
            Lesson lecture1 = _isuExtraService.AddLessonOGNP(lessonNumber1, "Nikolay", audience1);
            Lesson lecture2 = _isuExtraService.AddLessonOGNP(lessonNumber2, "Alexandr", audience2);

            _isuExtraService.AddLessonToOGNPStream(p1, day1, lecture1);
            _isuExtraService.AddLessonToOGNPStream(k2, day2, lecture2);
            
            Assert.Catch<Exception>(() =>
            {
                _isuExtraService.AddStudentToOGNP(p1, ivan);
            });
        }
    }
}