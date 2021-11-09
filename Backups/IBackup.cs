namespace Backups
{
    public interface IBackup
    {
        void Add(string filePath, string fileName);
        void Remove(string filePath, string fileName);
        void MakeRestorePoint();
        void MakeVirtualMemory();
        bool CheckRestorePoint(int restorePointNumber, int filesNumber);
        bool IsFileHere(int restorePointNumber, string filePath);
    }
}