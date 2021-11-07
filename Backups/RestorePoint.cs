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

        private DateTime CreationTime { get; }
        private List<BackupFile> Files { get; }
        private List<ZipFile> ZipFiles { get; }
    }
}