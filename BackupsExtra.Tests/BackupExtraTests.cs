using System;
using Backups;
using BackupsExtra.Entities;
using BackupsExtra.Services;
using NUnit.Framework;

namespace BackupsExtra.Tests
{
    public class BackupExtraTests
    {
        private BackupExtra _backup;

        [SetUp]
        public void Setup()
        {
            IAlgorithm algorithm = new SplitStoragesAlgorithm();
            _backup = new BackupExtra(".", algorithm, new ConsoleLogging());
        }

        [Test]
        public void AddFileToJob_CheckBackups()
        {
            const string pathFile = "./../../..";
            _backup.AddFile(pathFile, "A");
            _backup.AddFile(pathFile, "B");
            _backup.MakeRestorePointExtra();
            const int filesNumberInRestorePoint1 = 2;
            _backup.RemoveFile(pathFile, "B");
            _backup.MakeRestorePointExtra();
            const int filesNumberInRestorePoint2 = 1;
            Assert.True(_backup.CheckRestorePoint(1, filesNumberInRestorePoint1), "fail on RP 1");
            Assert.True(_backup.IsFileHere(1, "./Backup/A_1.zip"), "file A1");
            Assert.True(_backup.IsFileHere(1, "./Backup/B_1.zip"), "file B1");
            Assert.True(_backup.CheckRestorePoint(2, filesNumberInRestorePoint2), "fail on RP 2");
            Assert.True(_backup.IsFileHere(2, "./Backup/A_2.zip"), "file A2");
            Assert.False(_backup.IsFileHere(2, "./Backup/B_2.zip"), "file B2");
        }

        [Test]
        public void CheckNumberLimits()
        {
            const string pathFile = "./../../..";
            _backup.AddFile(pathFile, "A");
            _backup.AddFile(pathFile, "B");
            _backup.MakeRestorePointExtra();
            _backup.RemoveFile(pathFile, "B");
            _backup.MakeRestorePointExtra();
            _backup.SetNumberLimit(1);
            _backup.PushToNumberLimit();
            int newNumberOfRestorePoints = 1;
            Assert.True(newNumberOfRestorePoints == _backup.RestorePoints.Count);

        }

        [Test]
        public void CheckTimeLimits()
        {
            const string pathFile = "./../../..";
            _backup.AddFile(pathFile, "A");
            _backup.AddFile(pathFile, "B");
            _backup.MakeRestorePointExtra();
            DateTime dateTimeLimit = DateTime.Now;
            _backup.RemoveFile(pathFile, "B");
            _backup.MakeRestorePointExtra();

            _backup.SetTimeLimit(dateTimeLimit);
            _backup.PushToTimeLimit();
            int newNumberOfRestorePoints = 1;
            Assert.True(newNumberOfRestorePoints == _backup.RestorePoints.Count);
        }

        [Test]
        public void Merge()
        {
            const string pathFile = "./../../..";
            _backup.AddFile(pathFile, "A");
            _backup.AddFile(pathFile, "B");
            _backup.MakeRestorePointExtra();
            _backup.RemoveFile(pathFile, "B");
            _backup.MakeRestorePointExtra();
            
            _backup.Merge();
            Assert.True(1 == _backup.RestorePoints.Count);
            Assert.False(_backup.CheckFile(1, "./Backup/A_1.zip"));
        }
    }
}