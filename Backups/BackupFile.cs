using System;
using System.IO;

namespace Backups
{
    public class BackupFile
    {
        public BackupFile(string filePath, string fileName)
        {
            FilePath = filePath;
            Name = fileName;
            FullName = filePath + "/" + fileName;
        }

        public string FilePath { get; }
        public string Name { get; }
        public string FullName { get; }

        // public void Update()
        // {
        //     Changed = false || LastUpdate != File.GetLastWriteTime(FullName);
        //     LastUpdate = File.GetLastWriteTime(FullName);
        //     BackupFileInfo = new FileInfo(FullName);
        // }
    }
}