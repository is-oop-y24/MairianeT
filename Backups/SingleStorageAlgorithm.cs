using System.Collections.Generic;
using Ionic.Zip;

namespace Backups
{
    public class SingleStorageAlgorithm : IAlgorithm
    {
        public List<ZipFile> MakeStorage(List<BackupFile> filesToSave, string path, string restorePointNumber)
        {
            var zipFiles = new List<ZipFile>();
            var zip = new ZipFile();
            string zipName = path + "/RestorePoint" + restorePointNumber + ".zip";
            foreach (BackupFile file in filesToSave)
            {
                zip.AddFile(file.FullName, "/");
            }

            var toSave = new Repository();
            toSave.SaveZip(zip, zipName);
            zipFiles.Add(zip);
            return zipFiles;
        }
    }
}