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

        public string FilePath { get; }
        public FileInfo BackupFileInfo { get; }
        public string Name { get; }
        public string FullName { get; }

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