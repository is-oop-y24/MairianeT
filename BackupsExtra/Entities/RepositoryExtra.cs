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
                if (File.Exists(backup.Path + "/RestorePoint" +
                                backup.RestorePoints[restorePointNumber].RestorePointNumber + ".zip"))
                {
                    File.Delete(backup.Path + "/RestorePoint" + backup.RestorePoints[restorePointNumber].RestorePointNumber + ".zip");
                }
            }
            else
            {
                foreach (BackupFile file in backup.RestorePoints[restorePointNumber].Files)
                {
                    if (File.Exists(backup.Path + "/" + file.Name + "_" +
                                    backup.RestorePoints[restorePointNumber].RestorePointNumber + ".zip"))
                    {
                        File.Delete(backup.Path + "/" + file.Name + "_" + backup.RestorePoints[restorePointNumber].RestorePointNumber + ".zip");
                    }
                }
            }

            backup.RestorePoints.Remove(backup.RestorePoints[restorePointNumber]);
        }

        public void RemoveFile(BackupExtra backup, RestorePoint restorePoint, BackupFile file)
        {
            if (File.Exists(backup.Path + "/" + file.Name + "_" + restorePoint.RestorePointNumber + ".zip"))
            {
                File.Delete(backup.Path + "/" + file.Name + "_" + restorePoint.RestorePointNumber + ".zip");
            }

            restorePoint.Files.Remove(file);
        }

        public void RenameFile(BackupExtra backup, RestorePoint oldRestorePoint, RestorePoint newRestorePoint, BackupFile file)
        {
            string oldName = backup.Path + "/" + file.Name + "_" + oldRestorePoint.RestorePointNumber + ".zip";
            string newName = backup.Path + "/" + file.Name + "_" + newRestorePoint.RestorePointNumber + ".zip";
            File.Move(oldName, newName);
        }

        public void FileRecovery(BackupFile file)
        {
            File.Create(file.FullName);
        }

        public void FileRecoveryToPath(BackupFile file, string path)
        {
            File.Create(path + "/" + file.Name);
        }
    }
}