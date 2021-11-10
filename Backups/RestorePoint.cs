using System;
using System.Collections.Generic;
using Ionic.Zip;

namespace Backups
{
    public class RestorePoint
    {
        public RestorePoint(List<BackupFile> filesToSave, string path, string restorePointNumber, IAlgorithm algorithm)
        {
            CreationTime = DateTime.Now;
            Files = filesToSave;
            ZipFiles = algorithm.MakeStorage(filesToSave, path, restorePointNumber);
        }

        public DateTime CreationTime { get; }
        public List<BackupFile> Files { get; }
        public List<ZipFile> ZipFiles { get; }
    }
}