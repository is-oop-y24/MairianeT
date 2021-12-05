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
            RestorePointNumber = restorePointNumber;
        }

        public string RestorePointNumber { get; set; }

        public DateTime CreationTime { get; set; }
        public List<BackupFile> Files { get; set; }
        public List<ZipFile> ZipFiles { get; set; }
    }
}