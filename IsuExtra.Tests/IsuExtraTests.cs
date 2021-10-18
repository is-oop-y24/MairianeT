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

        public void AddStudentToOGNP()
        {
            Megafaculty tint = _isuExtraService.AddMegafaculty("tint");
            Megafaculty ktu = _isuExtraService.AddMegafaculty("ktu");
            CourseNumber second = _isuExtraService.AddCourse(2, tint);
            Group third = _isuService.AddGroup(new GroupName("M3203"));
            Student Ivan = _isuService.AddStudent(third, "Ivan");

            OGNP lin = _isuExtraService.AddOGNP(tint.Name());
            OGNP kib = _isuExtraService.AddOGNP(ktu.Name());

            OGNPStream p1 = _isuExtraService.AddOgnpStream(lin);
            OGNPStream k2 = _isuExtraService.AddOgnpStream(kib);

            Class lecture1 = _isuExtraService.AddClassOGNP(2, "Nikolay", 329);
            Class lecture2 = _isuExtraService.AddClassMegafaculty(2, "Alexandr", 332, third);
            
            _isuExtraService.AddClassToOGNPStream(p1, 3, lecture1);
            _isuExtraService.AddClassToOGNPStream(k2, 3, lecture2);
            
            
        }
        
    }
}