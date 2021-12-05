using System.Collections.Generic;
using Ionic.Zip;

namespace Backups
{
    public class SingleStorageAlgorithm : IAlgorithm
    {
        private string _zipName;

        public List<ZipFile> MakeStorage(List<BackupFile> filesToSave, string path, string restorePointNumber)
        {
            var zipFiles = new List<ZipFile>();
            var zip = new ZipFile();
            _zipName = path + "/RestorePoint" + restorePointNumber + ".zip";
            foreach (BackupFile file in filesToSave)
            {
                zip.AddFile(file.FullName, "/");
            }

            var toSave = new Repository();
            toSave.SaveZip(zip, _zipName);
            zipFiles.Add(zip);
            return zipFiles;
        }

        public string ZipName()
        {
            return _zipName;
        }
    }
}