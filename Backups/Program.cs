namespace Backups
{
    internal class Program
    {
        private static void Main()
        {
            IAlgorithm algorithm = new SingleStorageAlgorithm();
            IBackup backup = new Backup(@"C:\Users\User\Desktop", algorithm);
            backup.Add(@"C:\Users\User\Desktop", "A");
            backup.Add(@"C:\Users\User\Desktop", "B");
            backup.MakeRestorePoint();
            backup.Remove(@"C:\Users\User\Desktop", "B");
            backup.MakeRestorePoint();
        }
    }
}
