using System.Collections.Generic;
using System.IO;

namespace Backups
{
    public class BackupFile
    {
        private string _data;
        public BackupFile(string filePath, string fileName)
        {
            BackupFileInfo = new FileInfo(filePath + "/" + fileName);
            Name = BackupFileInfo.Name;
            FullName = BackupFileInfo.FullName;
            FilePath = filePath;
        }

        public string FilePath { get; set; }

        public FileInfo BackupFileInfo { get; set; }
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