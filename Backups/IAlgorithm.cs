using System.Collections.Generic;
using Ionic.Zip;

namespace Backups
{
    public interface IAlgorithm
    {
        List<ZipFile> MakeStorage(List<BackupFile> filesToSave, string path, string restorePointNumber);
    }
}