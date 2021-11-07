using System.Collections.Generic;
using System.IO;
using Ionic.Zip;

namespace Backups
{
    public class SingleStorageAlgorithm : IAlgorithm
    {
        public SingleStorageAlgorithm()
        {
        }

        public List<ZipFile> MakeStorage(List<BackupFile> filesToSave, string path, string restorePointNumber)
        {
            var zipFiles = new List<ZipFile>();
            var zip = new ZipFile();
            string zipName = path + @"\RestorePoint" + restorePointNumber + ".zip";
            foreach (BackupFile file in filesToSave)
            {
                zip.AddFile(file.FullName, @"\");
            }

            zip.Save(zipName);
            zipFiles.Add(zip);
            return zipFiles;
        }
    }
}