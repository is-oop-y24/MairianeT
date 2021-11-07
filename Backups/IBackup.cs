namespace Backups
{
    public interface IBackup
    {
        void Add(string filePath);
        void Add(BackupFile newFile);
        void Remove(string filePath);
        void MakeRestorePoint();
    }
}