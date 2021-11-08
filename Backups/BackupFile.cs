using System.IO;

namespace Backups
{
    public class BackupFile
    {
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
    }
}