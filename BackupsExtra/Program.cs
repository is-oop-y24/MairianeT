using System;
using System.IO;
using Backups;
using BackupsExtra.Entities;
using BackupsExtra.Services;
using Ionic.Zip;

namespace BackupsExtra
{
    internal class Program
    {
        private static void Main()
        {
            IAlgorithm algorithm = new SplitStoragesAlgorithm();
            var backup = new BackupExtra(@"C:\Users\User\Desktop", algorithm, new ConsoleLogging());
            backup.AddFile(@"C:\Users\User\Desktop", "A");
            backup.AddFile(@"C:\Users\User\Desktop", "B");

            var saveJob = new Saving();
            saveJob.SaveJob(backup, @"C:\Users\User\Desktop\BackupJob.json");
        }
    }
}
