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
            Assert.True(File.Exists(@"./Backup/A_1.zip"), "file A1");
            Assert.True(File.Exists(@"./Backup/B_1.zip"), "file B1");
            Assert.True(File.Exists(@"./Backup/A_2.zip"), "file A2");
            Assert.False(File.Exists(@"./Backup/B_2.zip"), "file B2");
        }
    }
}