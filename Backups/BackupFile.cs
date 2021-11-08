﻿using System;
using System.IO;

namespace Backups
{
    public class BackupFile
    {
        public BackupFile(string filePath)
        {
            FilePath = filePath;
            BackupFileInfo = new FileInfo(filePath);
            Name = BackupFileInfo.Name;
            FullName = BackupFileInfo.FullName;
            LastUpdate = File.GetLastWriteTime(FullName);
            Changed = false;
        }

        public string FilePath { get; }
        public FileInfo BackupFileInfo { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool Changed { get; private set; }

        public void Update()
        {
            Changed = false || LastUpdate != File.GetLastWriteTime(FullName);
            LastUpdate = File.GetLastWriteTime(FullName);
            BackupFileInfo = new FileInfo(FullName);
        }
    }
}