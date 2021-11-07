using System;
using System.IO;
using NUnit.Framework;

namespace Backups.Tests
{
    public class BackupTests
    {
        private IBackup _backup;

        [SetUp]
        public void Setup()
        {
            IAlgorithm algorithm = new SplitStoragesAlgorithm();
                _backup = new Backup(@"./", algorithm);
        }

        [Test]
        public void AddFileA_AddFileB_MakePoint_RemoveFileB_MakePoint()
        {
            const string pathFileA = "./../../../A";
            const string pathFileB = "./../../../B";
            _backup.Add(pathFileA);
            _backup.Add(pathFileB);
            _backup.MakeRestorePoint();
            const int filesNumberInRestorePoint1 = 2;
            _backup.Remove(pathFileB);
            _backup.MakeRestorePoint();
            const int filesNumberInRestorePoint2 = 1;
            Assert.True(_backup.CheckRestorePoint(1, filesNumberInRestorePoint1), "fail on RP 1");
            Assert.True(_backup.CheckRestorePoint(2, filesNumberInRestorePoint2), "fail on RP 2");
        }
    }
}