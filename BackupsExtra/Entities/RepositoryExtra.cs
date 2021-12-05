using System;
using System.IO;
using Backups;
using BackupsExtra.Services;

namespace BackupsExtra.Entities
{
    public class RepositoryExtra : Repository
    {
        public void RemoveRestorePoint(BackupExtra backup, int restorePointNumber, IAlgorithm algorithm)
        {
            if (algorithm is SingleStorageAlgorithm)
            {
                File.Delete(algorithm.ZipName());
            }
            else
            {
                foreach (BackupFile file in backup.RestorePoints[restorePointNumber].Files)
                {
                    File.Delete(backup.Path + "/" + file.Name + "_" + algorithm.ZipName() + ".zip");
                }
            }

            backup.RestorePoints.Remove(backup.RestorePoints[restorePointNumber]);
        }
    }
}