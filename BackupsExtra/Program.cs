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
            IAlgorithm algorithm = new SingleStorageAlgorithm();
            var backup = new BackupExtra(@"C:\Users\User\Desktop", algorithm);
            backup.Add(@"C:\Users\User\Desktop", "A");
            backup.Add(@"C:\Users\User\Desktop", "B");
            backup.MakeRestorePoint();
            var my = new RepositoryExtra();
            my.RemoveRestorePoint(backup, 0, algorithm);
        }
    }
}
