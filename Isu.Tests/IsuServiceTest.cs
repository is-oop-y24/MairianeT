using Isu.Services;
using Isu.Tools;
using NUnit.Framework;
using Isu.Entities;

namespace Isu.Tests
{
    public class Tests
    {
        private IIsuService _isuService;

        [SetUp]
        public void Setup()
        {
            _isuService = new IsuService();
        }

        [Test]
        public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
        {
            Group third = _isuService.AddGroup(new GroupName("M3203"));
            Student Ivan = _isuService.AddStudent(third, "Ivan");

            Assert.AreEqual(Ivan.Group(), third);
            Assert.AreEqual(Ivan, third.FindStudent("Ivan"));
        }

        [Test]
        public void ReachMaxStudentPerGroup_ThrowException()
        {
            Group zero = _isuService.AddGroup(new GroupName("M3300"));
            Assert.Catch<IsuException>(() =>
            {
                for (int i = 0; i < 35; i++)
                {
                    Student current = _isuService.AddStudent(zero, "Vasya");
                }
            });
        }

        [Test]
        public void CreateGroupWithInvalidName_ThrowException()
        {
            Assert.Catch<IsuException>(() =>
            {
                Group sixth = _isuService.AddGroup(new GroupName("N2x06"));
            });
        }

        [Test]
        public void TransferStudentToAnotherGroup_GroupChanged()
        {
            Group second = _isuService.AddGroup(new GroupName("M3102"));
            Student Ann = _isuService.AddStudent(second, "Ann");

            Assert.AreEqual(Ann.Group(), second);
            Group first = _isuService.AddGroup(new GroupName("M3101"));
            _isuService.ChangeStudentGroup(Ann, first);
            Assert.AreEqual(Ann.Group(), first);
        }
    }
}