using System;
using System.Collections.Generic;
using System.IO;

namespace Backups
{
    public class VirtualBackup
    {
        public VirtualBackup(List<BackupFile> filesToSave)
        {
            Date = DateTime.Today.ToString("g");
            Files = new List<string>();
            foreach (BackupFile file in filesToSave)
            {
                Files.Add(File.ReadAllText(file.FullName));
            }
        }

        public string Date { get; }
        public List<string> Files { get; }
    }
}
