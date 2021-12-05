using System;
using System.IO;
using System.Security.Policy;
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
                    File.Delete(backup.Path + "/" + file.Name + "_" + backup.RestorePoints[restorePointNumber].RestorePointNumber + ".zip");
                }
            }

            backup.RestorePoints.Remove(backup.RestorePoints[restorePointNumber]);
        }

        public void RemoveFile(BackupExtra backup, RestorePoint restorePoint, BackupFile file)
        {
            File.Delete(backup.Path + "/" + file.Name + "_" + restorePoint.RestorePointNumber + ".zip");
            restorePoint.Files.Remove(file);
        }

        public void RenameFile(BackupExtra backup, RestorePoint oldRestorePoint, RestorePoint newRestorePoint, BackupFile file)
        {
            string oldName = backup.Path + "/" + file.Name + "_" + oldRestorePoint.RestorePointNumber + ".zip";
            string newName = backup.Path + "/" + file.Name + "_" + newRestorePoint.RestorePointNumber + ".zip";
            File.Move(oldName, newName);
        }
    }
}