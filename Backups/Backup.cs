using System.Collections.Generic;
using System.Linq;

namespace Backups
{
    public class Backup : IBackup
    {
        public Backup(string path, IAlgorithm algorithm)
        {
            BackupFiles = new List<BackupFile>();
            RestorePoints = new List<RestorePoint>();
            Algorithm = algorithm;
            CurrRepository = new Repository();
            Path = CurrRepository.MakeDirectory(path);
        }

        public string Path { get; set; }
        public List<BackupFile> BackupFiles { get; set; }
        public List<RestorePoint> RestorePoints { get; set; }
        public IAlgorithm Algorithm { get; set; }
        public Repository CurrRepository { get; set; }

        public void Add(string filePath, string fileName)
        {
            BackupFiles.Add(new BackupFile(filePath, fileName));
        }

        public void Remove(string filePath, string fileName)
        {
            BackupFile fileToRemove = BackupFiles.SingleOrDefault(r => (r.Name == fileName && r.FilePath == filePath));
            if (fileToRemove != null)
                BackupFiles.Remove(fileToRemove);
        }

        public void MakeRestorePoint()
        {
            var newRestorePoint = new RestorePoint(BackupFiles, Path, (RestorePoints.Count + 1).ToString(), Algorithm);
            RestorePoints.Add(newRestorePoint);
        }

        public void MakeVirtualMemory()
        {
            foreach (BackupFile file in BackupFiles)
            {
                file.AddFileData();
            }
        }

        public bool CheckRestorePoint(int restorePointNumber, int filesNumber)
        {
            return RestorePoints[restorePointNumber - 1].ZipFiles.Count == filesNumber;
        }

        public bool IsFileHere(int restorePointNumber, string filePath)
        {
            return RestorePoints[restorePointNumber - 1].ZipFiles.Any(file => file.Name == filePath);
        }
    }
}