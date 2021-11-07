namespace Backups
{
    public interface IBackup
    {
        void Add(string filePath);
        void Remove(string filePath);
        void MakeRestorePoint();
        bool CheckRestorePoint(int restorePointNumber);
    }
}