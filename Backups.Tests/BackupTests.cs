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
            _backup.Remove(pathFileB);
            _backup.MakeRestorePoint();
            Assert.True(_backup.CheckRestorePoint(1, 2), "fail on RP 1");
            Assert.True(_backup.CheckRestorePoint(2, 1), "fail on RP 2");
        }
    }
}