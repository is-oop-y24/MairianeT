﻿using System;
using System.Collections.Generic;
using System.Linq;
using Ionic.Zip;

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

        public void Add(string filePath, string fileName)
        {
            BackupFiles.Add(new BackupFile(filePath, fileName));
        }

        public void Remove(string filePath, string fileName)
        {
            BackupFile fileToRemove = BackupFiles.SingleOrDefault(r => r.FullName == filePath + "/" + fileName);
            if (fileToRemove != null)
                BackupFiles.Remove(fileToRemove);
        }

        public void MakeRestorePoint()
        {
            var newRestorePoint = new RestorePoint(BackupFiles, Path, (RestorePoints.Count + 1).ToString(), Algorithm);
            RestorePoints.Add(newRestorePoint);
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