﻿using System;
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

        private string Path { get; }
        private List<BackupFile> BackupFiles { get; }
        private List<RestorePoint> RestorePoints { get; }
        private IAlgorithm Algorithm { get; }
        private Repository CurrRepository { get; }

        public void Add(string filePath)
        {
            BackupFiles.Add(new BackupFile(filePath));
        }

        public void Add(BackupFile newFile)
        {
            BackupFiles.Add(newFile);
        }

        public void Remove(string filePath)
        {
            BackupFile fileToRemove = BackupFiles.SingleOrDefault(r => r.FilePath == filePath);
            if (fileToRemove != null)
                BackupFiles.Remove(fileToRemove);
        }

        public void MakeRestorePoint()
        {
            UpdateFiles();
            var newRestorePoint = new RestorePoint(BackupFiles, Path, (RestorePoints.Count + 1).ToString(), Algorithm);
            RestorePoints.Add(newRestorePoint);
        }

        public bool IsFileHere(int restorePointNumber, string filePath)
        {
            return RestorePoints[restorePointNumber].Files.Any(file => file.FilePath == filePath);
        }

        private void UpdateFiles()
        {
            foreach (BackupFile file in BackupFiles)
                file.Update();
        }
    }
}