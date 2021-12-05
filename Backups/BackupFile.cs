using System.Collections.Generic;
using System.IO;

namespace Backups
{
    public class BackupFile
    {
        private string _data;
        public BackupFile(string filePath, string fileName)
        {
            Name = fileName;
            FullName = filePath + "/" + fileName;
            FilePath = filePath;
        }

        public string FilePath { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }

        public void AddFileData()
        {
            _data = File.ReadAllText(FullName);
        }

        public string FileData()
        {
            return _data;
        }
    }
}