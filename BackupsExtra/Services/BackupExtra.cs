using System;
using System.Collections.Generic;
using System.Linq;
using Backups;
using BackupsExtra.Entities;
using BackupsExtra.Tool;

namespace BackupsExtra.Services
{
    public class BackupExtra : Backup
    {
        public BackupExtra(string path, IAlgorithm algorithm, ILogging logging)
        : base(path, algorithm)
        {
            Logging = logging;
            Repository = new RepositoryExtra();
        }

        public Limit TimeLimit { get; set; }
        public Limit NumberLimit { get; set; }
        public ILogging Logging { get; set; }
        public RepositoryExtra Repository { get; set; }

        public void SetTimeLimit(DateTime dateTime)
        {
            TimeLimit = new TimeLimit(this, dateTime);
            Logging.Logging("Time limit is set to " + dateTime);
        }

        public void SetNumberLimit(int maxNumber)
        {
            NumberLimit = new NumberLimit(this, maxNumber);
            Logging.Logging("Number limit is set at " + maxNumber + " restore points");
        }

        public void PushToNumberLimit()
        {
            for (int i = 0; i < NumberLimit.GetLimit(); i++)
            {
                Repository.RemoveRestorePoint(this, i, Algorithm);
            }

            Logging.Logging("restore points not running by the number limit deleted");
        }

        public void PushToTimeLimit()
        {
            for (int i = 0; i < TimeLimit.GetLimit(); i++)
            {
                Repository.RemoveRestorePoint(this, i, Algorithm);
            }

            Logging.Logging("restore points not running by the time limit deleted");
        }

        public void PushToHybridAllLimit()
        {
            for (int i = 0; i < Math.Max(NumberLimit.GetLimit(), TimeLimit.GetLimit()); i++)
            {
                Repository.RemoveRestorePoint(this, i, Algorithm);
            }

            Logging.Logging("restore points not running by the all limits deleted");
        }

        public void PushToHybridLeastOneLimit()
        {
            for (int i = 0; i < Math.Min(NumberLimit.GetLimit(), TimeLimit.GetLimit()); i++)
            {
                Repository.RemoveRestorePoint(this, i, Algorithm);
            }

            Logging.Logging("restore points that do not pass at least one limit are deleted");
        }

        public void Merge()
        {
            if (Algorithm is SingleStorageAlgorithm)
            {
                RestorePoints.RemoveAt(RestorePoints.Count - 2);
            }
            else
            {
                var filesToRemove = new List<BackupFile>();
                var filesToReplace = new List<BackupFile>();
                foreach (BackupFile file in RestorePoints[^2].Files)
                {
                    if (RestorePoints[^1].Files.Contains(file))
                    {
                        filesToRemove.Add(file);
                    }
                    else
                    {
                        RestorePoints[^1].Files.Add(file);
                        RestorePoints[^2].Files.Remove(file);
                        filesToReplace.Add(file);
                    }
                }

                foreach (BackupFile file in filesToRemove)
                {
                    Repository.RemoveFile(this, RestorePoints[^2], file);
                }

                foreach (BackupFile file in filesToReplace)
                {
                    Repository.RenameFile(this, RestorePoints[^2], RestorePoints[^1], file);
                }

                RestorePoints.RemoveAt(RestorePoints.Count - 2);
            }

            Logging.Logging("merge restore points");
        }

        public void RecoveringToOriginalLocation(BackupFile file)
        {
            Repository.FileRecovery(file);
            Logging.Logging("the file has been restored to original location");
        }

        public void RecoveringToDifferentLocation(BackupFile file, string path)
        {
            Repository.FileRecoveryToPath(file, path);
            Logging.Logging("the file has been restored to different location");
        }

        public void AddFile(string filePath, string fileName)
        {
            Add(filePath, fileName);
            Logging.Logging("file has been added");
        }

        public void RemoveFile(string filePath, string fileName)
        {
            Remove(filePath, fileName);
            Logging.Logging("file has been removed");
        }

        public void MakeRestorePointExtra()
        {
            MakeRestorePoint();
            Logging.Logging("Restore point has been created");
        }

        public void RemoveVirtualMemory()
        {
            BackupFiles.Clear();
        }

        public void MakeVirtualMemoryExtra()
        {
            MakeVirtualMemory();
            Logging.Logging("virtual memory has been created");
        }

        public bool CheckFile(int restorePointNumber, string filePath)
        {
            return RestorePoints[restorePointNumber - 1].Files.Any(file => file.Name == filePath);
        }
    }
}