namespace Backups
{
    public interface IBackup
    {
        void Add(string filePath, string fileName);
        void Remove(string filePath, string fileName);
        void MakeRestorePoint();
        void MakeVirtualBackup();
        bool CheckRestorePoint(int restorePointNumber, int filesNumber);
        bool CheckVirtualBackup(int virtualRestorePointNumber, string filePath);
        bool IsFileHere(int restorePointNumber, string filePath);
    }
}