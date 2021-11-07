namespace Backups
{
    public interface IBackup
    {
        void Add(string filePath);
        void Remove(string filePath);
        void MakeRestorePoint();
        bool IsFileHere(int restorePointNumber, string filePath);
    }
}